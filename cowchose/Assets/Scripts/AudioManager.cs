using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gunShot;

    public void PlaySound()
    {
        if (audioSource != null && gunShot != null)
            audioSource.PlayOneShot(gunShot);
    }
}
