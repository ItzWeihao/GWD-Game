using UnityEngine;

public class PhoneTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource m_AudioSource;

    public ObjectiveSceneTrigger objectiveSceneTrigger;

    private bool done = false;
    private bool interacted = false;
    private bool proceed = false;

    public void Interact()
    {
        if (!done && !interacted)
        {
            m_AudioSource.Stop();
            m_AudioSource.loop = false;
            m_AudioSource.PlayOneShot(SoundManagerScript.GetSound(SoundType.VOICE_RECORDING_01), 0.6f);
            interacted = true;
        } else if (interacted && !m_AudioSource.isPlaying)
        {
            m_AudioSource.loop = false;
            m_AudioSource.PlayOneShot(SoundManagerScript.GetSound(SoundType.PHONE_HANGUP), 0.6f);
        }
    }

    private void Update()
    {
        if (!m_AudioSource.isPlaying && gameObject.activeSelf)
        {
            if (!done && interacted)
            {
                done = true;
                m_AudioSource.loop = false;
                m_AudioSource.PlayOneShot(SoundManagerScript.GetSound(SoundType.PHONE_HANGUP), 0.6f);
                proceed = true;
            } 
            if (proceed)
            {
                objectiveSceneTrigger.SetActive();
            }
        }
    }
}
