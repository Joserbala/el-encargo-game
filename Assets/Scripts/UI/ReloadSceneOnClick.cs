using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReloadSceneOnClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{

    [SerializeField] private string trackClick = "Click";
    [SerializeField] private string trackOver = "Mouse Over Button";
    [SerializeField] private AudioManager audioManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioListener.pause = false;
        Time.timeScale = 1;
        EnemyBehaviour.canPlay = false; // static variables are put to the original value when loading a scene!
        audioManager.Play(trackClick);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioManager.Play(trackOver);
    }
}
