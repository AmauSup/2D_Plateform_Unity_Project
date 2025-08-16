using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectDestroyer;

    public AudioClip touchSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (touchSound == null)
            {
                return;
            }
            else
            {
                AudioManager.instance.PlayClipAt(touchSound, transform.position);
                Destroy(objectDestroyer);
            }
            
        }
    }
}
