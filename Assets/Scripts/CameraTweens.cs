using UnityEngine;
using DG.Tweening;

public class CameraTweens : MonoBehaviour
{

    [SerializeField] private GameObject playerP;
    [SerializeField] private Transform firstTransform;
    [SerializeField] private Transform secondTransform;

    public void SetFallingPosition()
    {
        transform.DOMove(firstTransform.position, 2).Play();
        transform.DORotate(firstTransform.rotation.eulerAngles, 2).Play();
    }

    public void SetThirdPersonPosition()
    {
        transform.parent = secondTransform;
        transform.DOLocalMove(Vector3.zero, 1).Play();
    }
}
