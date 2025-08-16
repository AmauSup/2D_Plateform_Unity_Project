using UnityEngine;
using UnityEngine.SceneManagement;


public class CloseSettings : MonoBehaviour
{
    public GameObject SettingsWindows;

    public void CloseSettingsMainMenu()
    {
        if (SettingsWindows != null)
        {
            SettingsWindows.SetActive(false);
        }
        else
        {
            Debug.LogWarning("SettingsWindows n'est pas assigné !");
        }
    }
}
