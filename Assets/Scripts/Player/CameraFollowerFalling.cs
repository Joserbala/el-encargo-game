using UnityEngine;

public class CameraFollowerFalling : MonoBehaviour
{

    [SerializeField] private IntVariableSO fallingSpeed;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        transform.Translate(Time.deltaTime * fallingSpeed.Value * transform.right);
    }
}
