using UnityEngine;
using UnityEngine.Events;

public class OnCollisionEnterEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onCollisionEnter;

    private void OnCollisionEnter(Collision other) => onCollisionEnter?.Invoke();
}
