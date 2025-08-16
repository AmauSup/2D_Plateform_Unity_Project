using UnityEngine;
using UnityEngine.UI;

public class PotionChest : MonoBehaviour
{
    private bool isInRange;

    public Animator animator;
    public int numberPotion;
    public Item potion;
    public AudioClip soundToPlay;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        animator.SetTrigger("Open_Chest");

        for (int i = 0; i < numberPotion; i++) 
        {
            Inventory.instance.content.Add(potion);
            Inventory.instance.UpdateInventoryUI();
        }
        
        AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
        GetComponent<BoxCollider2D>().enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}

