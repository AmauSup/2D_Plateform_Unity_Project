using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenuUI;
    public GameObject SettingsWindows;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        MovePlayer.instance.enabled = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0; // Met en pause
        gameIsPaused = true;
    }

   
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1; // Reprend le jeu
        gameIsPaused = false;
    }

    public void OpenSettingsMenu()
    {
        SettingsWindows.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        SettingsWindows.SetActive(false);
    }


    public void LoadMainMenu()
    {
        Resume();

        if (AudioManager.instance != null)
        {
            Destroy(AudioManager.instance.gameObject);
        }

        SceneManager.LoadScene("MainMenu");
    }

}
