using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificScene8 : MonoBehaviour
{
    public Animator fadeSystem;

System.Random aleatoire = new System.Random();

string[] levels = new string[] { "Level01", "Level02", "Level03", "Level04", "Level05", "Level06", "Level07" };

public GameObject itemButtonGroup;

public void Awake()
{
    fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
}

private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        LoadAndSaveData.instance.SaveData();
        StartCoroutine(loadNextScene());
    }
}

public IEnumerator loadNextScene()
{
    itemButtonGroup.SetActive(false);
    fadeSystem.SetTrigger("FadeIn");
    yield return new WaitForSeconds(1f);
    LoadAndSaveData.instance.SaveData();

    int mois = aleatoire.Next(0, levels.Length); // Génère un entier entre 0 et 1

    SceneManager.LoadScene(levels[mois]);
    itemButtonGroup.SetActive(true);
    }
}