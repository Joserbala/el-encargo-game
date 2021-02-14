using UnityEngine;
using UnityEngine.EventSystems;

public class ExitOnClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{

    [SerializeField] private string trackClick = "Click";
    [SerializeField] private string trackOver = "Mouse Over Button";
    [SerializeField] private AudioManager audioManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
        audioManager.Play(trackClick);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioManager.Play(trackOver);
    }
}
