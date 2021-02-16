using UnityEngine;
using UnityEngine.Events;

public class OnTriggerExitEventPlayer : MonoBehaviour
{

    [SerializeField] private UnityEvent onTriggerExit;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ThirdPersonHandler>())
        {
            onTriggerExit?.Invoke();
        }
    }
}
