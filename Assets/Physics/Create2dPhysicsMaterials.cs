using UnityEngine;

public class CreateSmoothPhysicsMaterial2D : MonoBehaviour
{
    void Start()
    {
        // Créer un Physics Material 2D
        PhysicsMaterial2D mat = new PhysicsMaterial2D("SmoothMaterial");

        // Réduire la friction pour éviter que le joueur colle aux murs
        mat.friction = 0f;

        // Supprimer le rebond
        mat.bounciness = 0f;

        // Appliquer le matériau à tous les Collider2D de l'objet
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D col in colliders)
        {
            col.sharedMaterial = mat;
        }

        Debug.Log("Smooth Physics Material 2D appliqué !");
    }
}
