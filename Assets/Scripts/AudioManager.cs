using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;

    public AudioMixerGroup soundEffectMixer;

    public static AudioManager instance;

    // Liste des scènes où on doit supprimer l'audio manager
    [SerializeField]
    private List<string> scenesToDestroyIn = new List<string> { "Level_Select", "MainMenu" }; // ← Mets ici les noms exacts

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Écoute le changement de scène
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        if (!audioSource.isPlaying && playlist.Length > 0)
        {
            audioSource.clip = playlist[0];
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource tempAudioSource = tempGO.AddComponent<AudioSource>();
        tempAudioSource.clip = clip;
        tempAudioSource.outputAudioMixerGroup = soundEffectMixer;
        tempAudioSource.Play();
        Destroy(tempGO, clip.length);
        return tempAudioSource;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scenesToDestroyIn.Contains(scene.name))
        {
            // Détruit l'instance et se désabonne
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
