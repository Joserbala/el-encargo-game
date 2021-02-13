using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterEvent : MonoBehaviour
{

    [SerializeField] private UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider other) => onTriggerEnter?.Invoke();
}
