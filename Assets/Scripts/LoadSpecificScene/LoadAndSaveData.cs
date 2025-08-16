using UnityEngine;
using System.Linq;
using System.Collections.Generic;


public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSaveData dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        Inventory.instance.UpdateTextUI();

        int currentHealth = PlayerPrefs.GetInt("playerHealth", PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);
        

        string[] itemsSaved = PlayerPrefs.GetString("inventoryItems","").Split(',');
        for (int i = 0; i < itemsSaved.Length; i++)
        {
            if (itemsSaved[i] != "")
            {

                int id = int.Parse(itemsSaved[i]);
                Item currentItem = ItemsDataBase.instance.allItems.Single(x => x.id == id);
                Inventory.instance.content.Add(currentItem);
            }
        }
        Inventory.instance.UpdateInventoryUI();
    }
    /*
    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);
        PlayerPrefs.SetInt("playerHealth", PlayerHealth.instance.currentHealth);

        if(CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }

        string itemInventory = string.Join(",",Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("inventoryItems", itemInventory);

        
        PlayerPrefs.Save(); // Force l'enregistrement immédiat


    }*/
    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);
        PlayerPrefs.SetInt("playerHealth", PlayerHealth.instance.currentHealth);

        // Récupère les niveaux déjà débloqués
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

        int currentLevel = CurrentSceneManager.instance.levelToUnlock;

        // Ajoute le niveau actuel s’il n’est pas déjà dans la liste
        if (!levelsUnlocked.Contains(currentLevel))
        {
            levelsUnlocked.Add(currentLevel);
        }

        // Enregistre la liste mise à jour
        string updatedString = string.Join(",", levelsUnlocked);
        PlayerPrefs.SetString("levelsUnlocked", updatedString);

        // Sauvegarde l’inventaire
        string itemInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("inventoryItems", itemInventory);

        PlayerPrefs.Save(); // Force l'enregistrement immédiat
    }

}