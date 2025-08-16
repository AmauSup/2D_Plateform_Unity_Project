using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour
{
    public int damageOnCollision ;
    public int coinsToRemove;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))

        {
            Inventory.instance.RemoveCoins(coinsToRemove);
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
