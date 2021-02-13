using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DiePanel : MonoBehaviour
{

    [SerializeField] private IntVariableSO timeToEnable;
    [SerializeField] private IntVariableSO reviveTime;
    [SerializeField] private Image image;

    public void GoToBlack()
    {
        gameObject.SetActive(true);
        image.DOFade(1, reviveTime.Value).Play();
    }

    public void StartFading()
    {
        image.DOFade(0, timeToEnable.Value).Play();
        Invoke(nameof(SetInactive), timeToEnable.Value);
    }

    private void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
