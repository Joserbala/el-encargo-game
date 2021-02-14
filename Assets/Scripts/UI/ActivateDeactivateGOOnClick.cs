using UnityEngine;
using UnityEngine.EventSystems;

public class ActivateDeactivateGOOnClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{

    [SerializeField] private bool activate;
    [SerializeField] private string trackClick = "Click";
    [SerializeField] private string trackOver = "Mouse Over Button";
    [SerializeField] private GameObject obj;
    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        if (!obj) Debug.LogWarning("No GameObject to deactive referenced.");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        obj.SetActive(activate);
        audioManager.Play(trackClick);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioManager.Play(trackOver);
    }
}
