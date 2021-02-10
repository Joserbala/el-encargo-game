using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameIsPaused;

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
        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
        }
    }
}
