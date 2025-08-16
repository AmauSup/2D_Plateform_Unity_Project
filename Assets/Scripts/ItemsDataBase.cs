using UnityEngine;

public class ItemsDataBase : MonoBehaviour
{
    public static ItemsDataBase instance;

    public Item[] allItems;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ItemsDataBase dans la sc�ne");
            return;
        }

        instance = this;
    }
}
