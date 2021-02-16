using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterEventPlayer : MonoBehaviour
{

    [SerializeField] private UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ThirdPersonHandler>())
        {
            onTriggerEnter?.Invoke();
        }
    }
}
