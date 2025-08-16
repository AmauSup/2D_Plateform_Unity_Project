using UnityEngine;

using System.Collections;



public class DeathZone : MonoBehaviour

{
    private Animator fadeSystem;

    public int damageOnCollision = 20;

    public int coinsToRemove;
    public GameObject itemButtonGroup; // Tu peux aussi utiliser CanvasGroup si tu pr�f�res fade

    

    private void Awake()

    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
            Inventory.instance.RemoveCoins(coinsToRemove);
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }



    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        // D�sactive les boutons
        itemButtonGroup.SetActive(false);

        // Fade in
        fadeSystem.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f); // dur�e du fade

        // Replace le joueur
        collision.transform.position = CurrentSceneManager.instance.respawnPoint;

        // R�affiche les boutons
        itemButtonGroup.SetActive(true);
    }
    

}