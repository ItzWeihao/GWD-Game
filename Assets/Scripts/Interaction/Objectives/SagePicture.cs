using UnityEngine;

public class SagePicture : MonoBehaviour
{
    public PictureManager _pictureManager;
    public GameObject _picture;
    private bool hasInteracted;

    public GameObject voiceMemo;
    private AudioSource _audioSource;

    private void Awake()
    {
        hasInteracted = false;
        _audioSource = voiceMemo.GetComponent<AudioSource>();
    }

    public void Interacting()
    {
        if (!hasInteracted)
        {
            hasInteracted = true;
            _pictureManager.CountInteractions();
        }
    }

    public void EnableRobinPicture()
    {
        if (_picture != null)
        {
            _picture.SetActive(true);
        }
    }

    public void PlayVoiceRecording()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }
}
