using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class ThirdPersonHandler : MonoBehaviour
{

    private bool isDying = false;
    private bool isOnTheground = false; // Whether has landed or not on the ground of the last part of the game
    private float hValue;
    private float vValue;
    private Vector3 movementVector;
    private Vector3 rotationVector;
    private Quaternion rotationQuaternion;

    [SerializeField] private float timeToDeactivateEndGame = 2;
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float rotationSpeed = 5;
    [SerializeField] private string animBoolWalking = "IsWalking";
    [SerializeField] private string animTriggerDie = "Die";
    [SerializeField] private string animTriggerResucitate = "Resucitate";
    [SerializeField] private string hAxis = "Horizontal";
    [SerializeField] private string vAxis = "Vertical";
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip walkingSounds;
    [SerializeField] private AudioSource characterAS;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Collider coll;
    [SerializeField] private IntVariableSO reviveTime;
    [SerializeField] private IntVariableSO timeToEnable;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform initialTransform;
    [SerializeField] private Transform lastTransform;
    [SerializeField] private UnityEvent onDie;
    [SerializeField] private UnityEvent onRevive;

    private void Awake()
    {
        if (!animator) Debug.LogWarning("No Animator referenced.");
        if (!mainCamera) Debug.LogWarning("No Camera referenced.");
        if (!rb) Debug.LogWarning("No Rigidbody referenced.");
        if (!coll) Debug.LogWarning(("No Collider referenced."));
        if (!walkingSounds) Debug.LogWarning("No walking sounds have been referenced.");
    }

    private void Start()
    {
        characterAS.volume = .5f;
    }

    private void Update()
    {
        if (!isOnTheground)
            CheckGround();
        else if (!isDying)
            GetInputs();
    }

    /// <summary>
    /// Updates isOnTheGround to start or not updating the movement and animations.
    /// </summary>
    private void CheckGround()
    {
        if (transform.position.y < -105.4f)
            isOnTheground = true;
    }

    private void FixedUpdate()
    {
        if (!isDying && isOnTheground)
        {
            DoMove();
            DoRotate();
        }
    }

    private void GetInputs()
    {
        hValue = Input.GetAxisRaw(hAxis);
        vValue = Input.GetAxisRaw(vAxis);
    }

    private void DoMove()
    {
        movementVector = new Vector3(hValue, 0, vValue).normalized;

        UpdateAnimatorAndSounds();

        movementVector = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0) * movementVector;

        rb.MovePosition(Time.deltaTime * movementSpeed * movementVector + rb.position);
    }

    private void UpdateAnimatorAndSounds()
    {
        if ((hValue != 0 || vValue != 0))
        {
            animator.SetBool(animBoolWalking, true);

            if (!characterAS.isPlaying)
            {
                characterAS.pitch = Random.Range(.8f, 1.2f);
                characterAS.PlayOneShot(walkingSounds);
            }
        }
        else
        {
            animator.SetBool(animBoolWalking, false);
            characterAS.Stop();
        }
    }

    private void DoRotate()
    {
        rotationVector = new Vector3(hValue, 0, vValue);

        rotationVector = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0) * rotationVector;

        if (rotationVector != Vector3.zero)
        {
            rotationQuaternion = Quaternion.LookRotation(rotationVector);

            rb.MoveRotation(Quaternion.Lerp(rb.rotation, rotationQuaternion, Time.deltaTime * rotationSpeed));
        }
    }

    public void PrepareThirdPerson()
    {
        transform.DOMove(initialTransform.position, 2).Play();
        transform.DORotate(initialTransform.rotation.eulerAngles, 2).Play();

        animator.SetBool(animBoolWalking, false);

        rb.useGravity = true;
    }

    public void ExecuteLastPosition()
    {
        transform.DOMove(lastTransform.position, timeToDeactivateEndGame).Play();
        transform.DORotate(lastTransform.rotation.eulerAngles, timeToDeactivateEndGame).Play();

        animator.SetBool(animBoolWalking, true);
        this.enabled = false;
    }

    public void DoDying()
    {
        this.coll.enabled = false;
        this.enabled = false;
        this.animator.SetTrigger(animTriggerDie);
        this.rb.useGravity = false;
        this.isDying = true;

        onDie?.Invoke();

        Invoke(nameof(Revive), reviveTime.Value);
    }

    private void Revive()
    {
        onRevive?.Invoke();

        transform.position = initialTransform.position;

        this.animator.SetTrigger(animTriggerResucitate);
        this.coll.enabled = true;
        this.rb.useGravity = true;
        this.isDying = false;

        Invoke(nameof(EnableThis), timeToEnable.Value);
    }

    private void EnableThis() => this.enabled = true;

}