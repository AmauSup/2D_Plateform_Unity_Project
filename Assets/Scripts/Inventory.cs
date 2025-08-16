using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;

    public List<Item> content = new List<Item>();
    public int contentCurrentIndex = 0;
    public Image itemImageUI;
    public Text itemNameUI;
    public Sprite emptyItemImage;

    public PlayerEffects playerEffects;

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }

        instance = this;
    }
    
    private void Start()
    {
        UpdateInventoryUI();
    }

    public int GetCoinsCount()
    {
        return coinsCount;
    }

    public void ConsumeItem()
    {
        if (content.Count == 0)
        {
            return;
        }

        Item currentItem = content[contentCurrentIndex];
        if (currentItem.itemName == "HealthPotion") 
        {
            if (PlayerHealth.instance.GetCurrentHealth() + currentItem.hpGiven <= 100)
            {
                PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
                content.Remove(currentItem);
            }

        }
        else if (currentItem.itemName == "SpeedPotion")
        {
            if (MovePlayer.instance.moveSpeed + currentItem.speedGiven <= 450)
            {
                playerEffects.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
                content.Remove(currentItem);
            }
        }

        else
        {
            playerEffects.AddJump(currentItem.jumpGiven, currentItem.jumpDuration);
            content.Remove(currentItem);
        }

        GetNextItem();
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {
        if (content.Count == 0)
        {
            return;
        }

        contentCurrentIndex++;
        if (contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }


    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }

        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if (content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].itemName;
        }
        else
        {
            itemImageUI.sprite = emptyItemImage;
            itemNameUI.text = "";
        }
    }
    



    public void AddCoins(int count)
    {
        coinsCount += count;
        UpdateTextUI();
    }

    public void RemoveCoins(int count)
    {
        if ((coinsCount - count) >= 0)
        {
            coinsCount -= count;
            UpdateTextUI();
        }
        else
        {
            coinsCount = 0;
            UpdateTextUI();
        }
    }

    public void UpdateTextUI()
    {
        coinsCountText.text = coinsCount.ToString();
    }
}