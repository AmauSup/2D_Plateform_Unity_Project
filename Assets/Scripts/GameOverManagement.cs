using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManagement : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManagement instance;

    public GameObject SettingsWindows;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance GameOverManagement dans la scène");
            return;
        }

        instance = this;

    }

    public void OnPlayerDeath()
    {
        
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);

        PlayerHealth.instance.Respawn();

        PlayerHealth.instance.transform.position = CurrentSceneManager.instance.respawnPoint;

        gameOverUI.SetActive(false);
    }

    public void MainMenu()
    {
        if (AudioManager.instance != null)
        {
            Destroy(AudioManager.instance.gameObject);
        }

        SceneManager.LoadScene("MainMenu");
    }
    

    public void OpenSettingsMenu()
    {
        SettingsWindows.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        SettingsWindows.SetActive(false);
    }

    /*
    public void QuitButton()
    {
        Application.Quit();
    }*/
}
