using UnityEngine;
using UnityEngine.EventSystems;

public class ActivateDeactivateGOOnClick : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private bool activate;
    [SerializeField] private GameObject obj;

    private void Awake()
    {
        if (!obj) Debug.LogWarning("No GameObject to deactive referenced.");
    }

    public void OnPointerClick(PointerEventData eventData) => obj.SetActive(activate);
}
