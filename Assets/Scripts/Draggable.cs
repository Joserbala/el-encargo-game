using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{
    private float distance;

    private void Start()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
    }

    private void OnMouseDrag()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }
}
