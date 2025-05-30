using UnityEngine;

public class VoiceInteraction : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject nextRecorder;
    public GameObject redLight;
    public GameObject SagePicture;
    public GameObject disableLight;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRecorder()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void EnableNextRecorder()
    {
        if (nextRecorder != null)
        {
            nextRecorder.SetActive(true);
        }
        if (redLight != null)
        {
            redLight.SetActive(true);
        }
        if (SagePicture != null)
        {
            SagePicture.SetActive(true);
        }
        if (disableLight != null)
        {
            disableLight.SetActive(false);
        }
    }
}
