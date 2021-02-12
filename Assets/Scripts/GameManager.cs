using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseResumeGame();
        }
    }

    private void PauseResumeGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
