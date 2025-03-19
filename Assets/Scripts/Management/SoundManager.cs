using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource soundObject;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public void PlaySoundClip(AudioClip audioClip, Transform spawnTransform, float volume, bool loop)
    {
        AudioSource audioSource = Instantiate(soundObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.Play();

        if (!loop)
        {
            float audioLength = audioSource.clip.length;

            Destroy(audioSource.gameObject, audioLength);
        }
        else
        {
            audioSource.loop = loop;
        }
    }

    public void StopSoundClip(AudioClip audioClip)
    {
        Destroy(soundObject);
    }
}
