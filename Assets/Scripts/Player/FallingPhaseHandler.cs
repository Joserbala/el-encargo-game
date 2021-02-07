using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class FallingPhaseHandler : MonoBehaviour
{

    private float hValue;
    private float vValue;
    private Vector3 hVector;
    private Vector3 vVector;
    private Vector3 vResult;

    [SerializeField] private float fallingSpeed = 5;
    [SerializeField] private float glidingSpeed = 10;
    [SerializeField] private string horizontalAxis = "Horizontal";
    [SerializeField] private string verticalAxis = "Vertical";
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform startT;
    [SerializeField] private UnityEvent prepareStartFalling;

    private void Awake()
    {
        if (!rb)
            Debug.LogError("No Rigidbody referenced in the script.");
    }

    private void Update()
    {
        hValue = Input.GetAxisRaw(horizontalAxis);
        vValue = Input.GetAxisRaw(verticalAxis);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        hVector = transform.right * hValue;
        vVector = transform.up * vValue;

        vResult = (hVector + vVector).normalized;

        rb.MovePosition(Time.deltaTime * glidingSpeed * vResult + rb.position);

        rb.MovePosition(Time.deltaTime * fallingSpeed * transform.forward + rb.position);
    }

    public void PrepareStartFalling()
    {
        transform.DOMove(startT.position, 2).Play();
        transform.DORotateQuaternion(startT.rotation, 2).Play();

        prepareStartFalling?.Invoke();

        this.enabled = true;
    }
}
