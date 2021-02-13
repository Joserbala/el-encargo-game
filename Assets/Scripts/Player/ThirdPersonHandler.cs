using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class ThirdPersonHandler : MonoBehaviour
{

    private float hValue;
    private float vValue;
    private Vector3 movementVector;
    private Vector3 rotationVector;
    private Quaternion rotationQuaternion;

    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float rotationSpeed = 5;
    [SerializeField] private string animBoolWalking = "IsWalking";
    [SerializeField] private string animTriggerDie = "Die";
    [SerializeField] private string animTriggerResucitate = "Resucitate";
    [SerializeField] private string hAxis = "Horizontal";
    [SerializeField] private string vAxis = "Vertical";
    [SerializeField] private Animator animator;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Collider coll;
    [SerializeField] private IntVariableSO reviveTime;
    [SerializeField] private IntVariableSO timeToEnable;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform initialTransform;
    [SerializeField] private UnityEvent onDie;
    [SerializeField] private UnityEvent onRevive;

    private void Awake()
    {
        if (!animator) Debug.LogWarning("No Animator referenced.");
        if (!mainCamera) Debug.LogWarning("No Camera referenced.");
        if (!rb) Debug.LogWarning("No Rigidbody referenced.");
        if (!coll) Debug.LogWarning(("No Collider referenced."));
    }

    private void Update()
    {
        GetInputs();
    }

    private void FixedUpdate()
    {
        DoMove();
        DoRotate();
    }

    private void GetInputs()
    {
        hValue = Input.GetAxisRaw(hAxis);
        vValue = Input.GetAxisRaw(vAxis);
    }

    private void DoMove()
    {
        movementVector = new Vector3(hValue, 0, vValue).normalized;

        UpdateAnimator();

        movementVector = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0) * movementVector;

        rb.MovePosition(Time.deltaTime * movementSpeed * movementVector + rb.position);
    }

    private void UpdateAnimator()
    {
        if (hValue != 0 || vValue != 0)
        {
            animator.SetBool(animBoolWalking, true);
        }
        else
        {
            animator.SetBool(animBoolWalking, false);
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

    public void DoDying()
    {
        this.coll.enabled = false;
        this.enabled = false;
        this.animator.SetTrigger(animTriggerDie);
        this.rb.useGravity = false;

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

        Invoke(nameof(EnableThis), timeToEnable.Value);
    }

    private void EnableThis() => this.enabled = true;

}