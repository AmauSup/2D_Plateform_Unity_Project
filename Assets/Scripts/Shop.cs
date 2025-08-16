using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{

    public bool open;
    public static Shop instance;

    public List<Item> content = new List<Item>();

    public GameObject ShopWindows;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Shop dans la scène");
            return;
        }

        instance = this;

        ShopWindows.SetActive(false);
        open = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && (open==false))
        {
            OpenShop();
        }
        else if(Input.GetKeyDown(KeyCode.F) && (open == true))
        {
            CloseShop();
        }
    }

    public void OpenShop()
    {
        ShopWindows.SetActive(true);
        open = true;
    }

    public void CloseShop()
    {
        ShopWindows.SetActive(false);
        open = false;
    }

    public void BuyPotionHealth()
    {
        int nbrcoins = Inventory.instance.GetCoinsCount();
        if (nbrcoins < 10)
        {
            return;
        }
        else
        {
            Inventory.instance.RemoveCoins(10);
            Inventory.instance.content.Add(content[0]);
            Inventory.instance.UpdateInventoryUI();
        }
    }
    public void BuyPotionJump()
    {
        int nbrcoins = Inventory.instance.GetCoinsCount();
        if (nbrcoins < 10)
        {
            return;
        }
        else
        {
            Inventory.instance.RemoveCoins(10);
            Inventory.instance.content.Add(content[1]);
            Inventory.instance.UpdateInventoryUI();
        }
    }
    public void BuyPotionSpeed()
    {
        int nbrcoins = Inventory.instance.GetCoinsCount();
        if (nbrcoins < 10)
        {
            return;
        }
        else
        {
            Inventory.instance.RemoveCoins(10);
            Inventory.instance.content.Add(content[2]);
            Inventory.instance.UpdateInventoryUI();
        }
    }


}
