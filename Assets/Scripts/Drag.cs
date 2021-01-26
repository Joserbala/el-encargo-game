using UnityEngine;

public class Drag : MonoBehaviour
{

    private float distance = 10;

    [SerializeField] private Camera introCamera;

    private void Start()
    {
        if (introCamera)
            distance = Vector3.Distance(transform.position, introCamera.transform.position);
        else
            Debug.LogError("No camera has been found.");
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
    }
}
