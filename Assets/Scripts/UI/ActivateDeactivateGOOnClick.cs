using UnityEngine;
using UnityEngine.EventSystems;

public class ActivateDeactivateGOOnClick : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private bool activate;
    [SerializeField] private GameObject obj;

    public void OnPointerClick(PointerEventData eventData) => obj.SetActive(activate);
}
