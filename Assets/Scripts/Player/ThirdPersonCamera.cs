using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    private float xValue;
    private float yValue;

    [SerializeField] private bool invertYAxis = false;
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] private string xAxis = "Mouse X";
    [SerializeField] private string yAxis = "Mouse Y";
    [SerializeField] private Transform head;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        DoRotate();
    }

    private void DoRotate()
    {
        xValue += Input.GetAxis(xAxis) * rotationSpeed;
        yValue += Input.GetAxis(yAxis) * rotationSpeed * (invertYAxis ? 1 : -1);

        yValue = Mathf.Clamp(yValue, -35, 60);

        head.rotation = Quaternion.Euler(yValue, xValue, 0);
        transform.LookAt(head);
    }
}
