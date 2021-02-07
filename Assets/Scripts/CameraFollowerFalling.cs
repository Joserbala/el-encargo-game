using UnityEngine;

public class CameraFollowerFalling : MonoBehaviour
{

    [SerializeField] private float fallingSpeed = 3;

    private void LateUpdate()
    {
        transform.Translate(Time.deltaTime * fallingSpeed * transform.right);
    }
}
