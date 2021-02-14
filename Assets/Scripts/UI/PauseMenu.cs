using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused { get => gameIsPaused; private set => gameIsPaused = value; }

    [SerializeField] private static bool gameIsPaused = false;
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
    [SerializeField] private GameObject pausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);

        AudioListener.pause = false;

        DisplayCursor(false);

        Time.timeScale = 1;
        GameIsPaused = false;
    }

    private void PauseGame()
    {
        pausePanel.SetActive(true);

        AudioListener.pause = true;

        DisplayCursor(true);

        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void DisplayCursor(bool visibleCursor)
    {
        Cursor.visible = visibleCursor;

        Cursor.lockState = visibleCursor ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
