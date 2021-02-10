using DG.Tweening;
using UnityEngine;

public class ThirdPersonHandler : MonoBehaviour
{

    private float hValue;
    private float vValue;
    private Vector3 movementVector;
    private Vector3 rotationVector;
    private Quaternion rotationQuaternion;

    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float rotationSpeed = 5;
    [SerializeField] private string hAxis = "Horizontal";
    [SerializeField] private string vAxis = "Vertical";
    [SerializeField] private Animator animator;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform initialTransform;

    private void Awake()
    {
        if (!animator) Debug.LogWarning("No Animator referenced.");
        if (!mainCamera) Debug.LogWarning("No Camera referenced.");
        if (!rb) Debug.LogWarning("No Rigidbody referenced.");
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

        movementVector = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0) * movementVector;

        rb.MovePosition(Time.deltaTime * movementSpeed * movementVector + rb.position);
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

    public void SetInitialTransform()
    {
        transform.DOMove(initialTransform.position, 2).Play();
        transform.DORotate(initialTransform.rotation.eulerAngles, 2).Play();

        this.enabled = true;
    }
}
