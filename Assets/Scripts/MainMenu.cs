using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject settingsWindow; 
    public void StartGame()
    {
        SceneManager.LoadScene("Level_Select");
    }

    public void SettingsButton() 
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsButton()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Application.ExternalEval("window.location.href = 'https://google.com';");
#else
        Application.Quit();
#endif
    }




    public void ClearSavedData()
    {
        PlayerPrefs.DeleteKey("coinsCount");  // Efface uniquement les pièces
        PlayerPrefs.DeleteKey("inventoryItems");  // Efface uniquement l'inventaire
        PlayerPrefs.DeleteAll();
    }
}
