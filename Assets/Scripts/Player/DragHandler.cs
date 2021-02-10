using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private float distance;
    private Vector3 mousePosition;
    private Vector3 objPosition;
    private Vector3 startPosition;

    [SerializeField] private FallingPhaseHandler fallingPhaseHandler;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private UnityEvent prepareFallingPhase;

    private void Awake()
    {
        if (!rb) Debug.LogWarning("No Rigidbody referenced.");
    }

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
            DoEndDragFalling();
        }
        Debug.Log("OnEndDrag");
    }

    private void DoEndDragFalling()
    {
        prepareFallingPhase?.Invoke();

        this.enabled = false;
    }
}
