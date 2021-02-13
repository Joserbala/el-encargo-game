using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterEventPlayer : MonoBehaviour
{

    [SerializeField] private UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ThirdPersonHandler>(out ThirdPersonHandler controller))
        {
            onTriggerEnter?.Invoke();
        }
    }
}
