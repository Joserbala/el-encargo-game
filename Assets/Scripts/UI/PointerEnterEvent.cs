using UnityEngine;
using UnityEngine.EventSystems;

public class PointerEnterEvent : MonoBehaviour, IPointerEnterHandler
{

    [SerializeField] private string trackEnter = "Mouse Over Button";
    [SerializeField] private AudioManager audioManager;

    public void OnPointerEnter(PointerEventData eventData) => audioManager.Play(trackEnter);
}
