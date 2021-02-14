using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerClickSoundEvent : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private string trackClick = "Click";
    [SerializeField] private AudioManager audioManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        audioManager.Play(trackClick);
    }
}
