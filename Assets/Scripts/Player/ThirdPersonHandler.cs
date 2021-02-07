using DG.Tweening;
using UnityEngine;

public class ThirdPersonHandler : MonoBehaviour
{

    [SerializeField] private Transform initialTransform;

    public void SetInitialTransform()
    {
        transform.DOMove(initialTransform.position, 2).Play();
        transform.DORotateQuaternion(initialTransform.rotation, 2).Play();
    }
}
