using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class FallingPhaseHandler : MonoBehaviour
{

    private float hValue;
    private float vValue;
    private Vector3 hVector;
    private Vector3 vVector;
    private Vector3 movementVector;

    [SerializeField] private float glidingSpeed = 10;
    [SerializeField] private IntVariableSO fallingSpeed;
    [SerializeField] private string horizontalAxis = "Horizontal";
    [SerializeField] private string verticalAxis = "Vertical";
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform startT;
    [SerializeField] private UnityEvent prepareStartFalling;

    private void Awake()
    {
        if (!rb) Debug.LogWarning("No Rigidbody referenced.");
    }

    private void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        hValue = Input.GetAxisRaw(horizontalAxis);
        vValue = Input.GetAxisRaw(verticalAxis);
    }

    private void FixedUpdate()
    {
        DoMove();
    }

    private void DoMove()
    {
        hVector = transform.right * hValue;
        vVector = transform.up * vValue;

        movementVector = (hVector + vVector).normalized;

        rb.MovePosition(Time.deltaTime * glidingSpeed * movementVector + rb.position);

        rb.MovePosition(Time.deltaTime * fallingSpeed.Value * transform.forward + rb.position);
    }

    public void PrepareFallingPhase()
    {
        transform.DOMove(startT.position, 2).Play();
        transform.DORotate(startT.rotation.eulerAngles, 2).Play();

        prepareStartFalling?.Invoke();

        this.enabled = true;
    }
}
