using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq; // Pour Select, Contains
using System.Collections.Generic; // Pour List<int>

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;

    private void Start()
    {
        // Lire les niveaux débloqués
        string levelsUnlockedString = PlayerPrefs.GetString("levelsUnlocked", "");
        List<int> levelsUnlocked = new List<int>();

        if (!string.IsNullOrEmpty(levelsUnlockedString))
        {
            levelsUnlocked = levelsUnlockedString
                .Split(',')
                .Select(int.Parse)
                .Distinct()
                .ToList();
        }
        if (!levelsUnlocked.Contains(1))
        {
            levelsUnlocked.Add(1);
        }
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelNumber = i + 1;

            // Active le bouton seulement si le niveau est dans la liste
            levelButtons[i].interactable = levelsUnlocked.Contains(levelNumber);
        }
    }

    public void LoadLevelPassed(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
