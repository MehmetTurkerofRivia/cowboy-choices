using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicClips;
    private AudioSource audioSource;
    private int lastClipIndex = -1;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.2f;
    }

    void Start()
    {
        PlayRandomMusic();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayRandomMusic();
        }
    }

    void PlayRandomMusic()
    {
        if (musicClips.Length == 0) return;

        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, musicClips.Length);
        } while (musicClips.Length > 1 && randomIndex == lastClipIndex);

        lastClipIndex = randomIndex;
        audioSource.clip = musicClips[randomIndex];
        audioSource.Play();
    }
}
