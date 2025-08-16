using UnityEngine;

public class PickupBonus : MonoBehaviour
{

    public AudioClip sound;
    public PlayerEffects playerEffects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            playerEffects.AddSpeed(50,10);
            Destroy(gameObject);
        }
    }
}
