using UnityEngine;

public class ReferenceChecker : MonoBehaviour
{
    void Start()
    {
        Debug.Log("<color=cyan>=== Vérification des références ===</color>");

        // Vérifie Inventory
        if (Inventory.instance == null)
        {
            Debug.LogError("❌ Inventory.instance est null !");
        }
        else
        {
            if (Inventory.instance.coinsCountText == null)
                Debug.LogError("❌ coinsCountText de Inventory n'est pas assigné !");
        }

        // Vérifie PlayerHealth
        if (PlayerHealth.instance == null)
        {
            Debug.LogError("❌ PlayerHealth.instance est null !");
        }
        else
        {
            if (PlayerHealth.instance.healthBar == null)
                Debug.LogError("❌ healthBar de PlayerHealth n'est pas assigné !");
            if (PlayerHealth.instance.graphics == null)
                Debug.LogWarning("⚠️ graphics (SpriteRenderer) de PlayerHealth n'est pas assigné !");
        }

        // Vérifie LoadAndSaveData
        if (LoadAndSaveData.instance == null)
        {
            Debug.LogError("❌ LoadAndSaveData.instance est null !");
        }

        // Vérifie AudioManager si utilisé
        if (AudioManager.instance == null)
        {
            Debug.LogWarning("⚠️ AudioManager.instance est null (si utilisé dans les sons de hit/mort)");
        }

        Debug.Log("<color=green>✅ Vérification terminée</color>");
    }
}
