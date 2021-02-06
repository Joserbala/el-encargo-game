using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private float distance;
    [SerializeField] private Rigidbody rb;
    private Vector3 mousePosition;
    private Vector3 objPosition;
    private Vector3 startPosition;

    private void Start()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
        Debug.Log("OnDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.position.x > -0.05)
        {
            transform.position = startPosition;
        }
        else
        {
            rb.constraints &= ~RigidbodyConstraints.FreezePositionY; // Unfreezing the Y position
            this.enabled = false;
        }
        Debug.Log("OnEndDrag");
    }
}
