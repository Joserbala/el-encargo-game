using UnityEngine;
using DG.Tweening;

public class LightTween : MonoBehaviour
{
    [SerializeField] private float newIntensity = 4;
    [SerializeField] private float tweenDuration = 2;
    [SerializeField] private Light blinkingLights;
    [SerializeField] private Transform newLightsT;
    [SerializeField] private Color colorTween;

    public void ActivateLighting()
    {
        blinkingLights.DOColor(colorTween, tweenDuration).Play();
        blinkingLights.DOIntensity(newIntensity, tweenDuration).Play();
        blinkingLights.transform.DOMove(newLightsT.position, tweenDuration).Play();
        blinkingLights.transform.DORotate(newLightsT.rotation.eulerAngles, tweenDuration).Play();
    }
}
