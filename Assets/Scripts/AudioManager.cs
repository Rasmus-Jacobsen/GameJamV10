using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music")]
    public AudioSource musicSource;
    public AudioClip musicScene1And2;
    public AudioClip musicScene3;

    [Header("UI Sounds")]
    public AudioClip buttonClickSfx;

    [Header("SFX")]
    public AudioSource sfxSource;

    [System.Serializable]
    public class HurtSoundSet
    {
        public EnemyType enemyType;
        public AudioClip[] hurtClips;
    }

    [Header("Hurt Sound Sets")]
    public HurtSoundSet[] hurtSoundSets;

    private Dictionary<EnemyType, AudioClip[]> hurtLookup;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        BuildLookup();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        PlayMusic(musicScene1And2);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0 || scene.buildIndex == 1 || scene.buildIndex == 11 || scene.buildIndex == 12)
        {
            PlayMusic(musicScene1And2);
        }
        else if (scene.buildIndex >= 2)
        {
            PlayMusic(musicScene3);
        }
    }

    void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip) return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    void BuildLookup()
    {
        hurtLookup = new Dictionary<EnemyType, AudioClip[]>();

        foreach (var set in hurtSoundSets)
        {
            hurtLookup[set.enemyType] = set.hurtClips;
        }
    }

    public void PlayHurtSfx(EnemyType enemyType)
    {
        if (!hurtLookup.ContainsKey(enemyType)) return;

        AudioClip[] clips = hurtLookup[enemyType];
        if (clips.Length == 0) return;

        // Slight pitch variation for polish
        sfxSource.pitch = Random.Range(0.95f, 1.05f);

        AudioClip clip = clips[Random.Range(0, clips.Length)];
        sfxSource.PlayOneShot(clip);
    }

    public void PlayButtonClick()
    {
        sfxSource.pitch = 1f;
        sfxSource.PlayOneShot(buttonClickSfx);
    }
}