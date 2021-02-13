using UnityEngine;
using DG.Tweening;

public class LightTween : MonoBehaviour
{
    [SerializeField] private Light blinkingLights;
    [SerializeField] private Transform newLightsT;
    [SerializeField] private Color colorTween;

    public void ActivateLighting()
    {
        blinkingLights.DOColor(colorTween, 2).Play();
        blinkingLights.DOIntensity(4, 2).Play();
        blinkingLights.transform.DOMove(newLightsT.position, 2).Play();
        blinkingLights.transform.DORotate(newLightsT.rotation.eulerAngles, 2).Play();
    }
}
