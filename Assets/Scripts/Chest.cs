using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{

    private bool isInRange;

    public Animator animator;
    public int coinsToAdd;
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
        Inventory.instance.AddCoins(coinsToAdd);
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