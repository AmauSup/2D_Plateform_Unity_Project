using UnityEngine;

public class CreateSmoothPhysicsMaterial2D : MonoBehaviour
{
    void Start()
    {
        // Cr�er un Physics Material 2D
        PhysicsMaterial2D mat = new PhysicsMaterial2D("SmoothMaterial");

        // R�duire la friction pour �viter que le joueur colle aux murs
        mat.friction = 0f;

        // Supprimer le rebond
        mat.bounciness = 0f;

        // Appliquer le mat�riau � tous les Collider2D de l'objet
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D col in colliders)
        {
            col.sharedMaterial = mat;
        }

        Debug.Log("Smooth Physics Material 2D appliqu� !");
    }
}
