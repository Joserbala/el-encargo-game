using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler
{
    private bool isDragging = false;
    private float distance;
    private Vector3 mousePosition;
    private Vector3 objPosition;
    private Vector3 startPosition;

    [SerializeField] private float timeToStopWalking = .5f;
    [SerializeField] private string animBoolWalking = "IsWalking";
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip onMouseOverSound;
    [SerializeField] private AudioSource playerAS;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private UnityEvent prepareFallingPhase;

    private void Awake()
    {
        if (!rb) Debug.LogWarning("No Rigidbody referenced.");
    }

    private void Start()
    {
        playerAS.volume = .4f;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isDragging)
            playerAS.PlayOneShot(onMouseOverSound);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.animator.SetBool(animBoolWalking, true);
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.position.x > -0.05)
        {
            transform.DOMove(startPosition, timeToStopWalking).Play();
            Invoke(nameof(StopWalking), timeToStopWalking);
        }
        else
        {
            DoStartFalling();
        }
    }

    private void StopWalking()
    {
        this.animator.SetBool(animBoolWalking, false);
        isDragging = false;
    }

    private void DoStartFalling()
    {
        prepareFallingPhase?.Invoke();

        this.enabled = false;
    }
}
