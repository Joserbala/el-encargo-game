using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private float distance;
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
    }

    public void OnDrag(PointerEventData eventData)
    {
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.position.x > -0.05)
            transform.position = startPosition;
        else
            Destroy(this);
    }
}
