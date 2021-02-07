using UnityEngine;
using UnityEngine.Events;

public class EndFallingTrigger : MonoBehaviour
{

    [SerializeField] private UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider other) => onTriggerEnter?.Invoke();
}
