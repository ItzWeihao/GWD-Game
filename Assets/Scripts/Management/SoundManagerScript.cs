//Author: Small Hedge Games
//Updated: 13/06/2024

using System;
using UnityEngine;
using UnityEngine.Audio;

public enum SoundType
{
    JUMPSCARE,
    DOORIMPACT,
    DOORSLAM,
    VOICE_RECORDING_01,
    PHONE_HANGUP,
    PHONE_RINGING
}

[RequireComponent(typeof(AudioSource))]
public class SoundManagerScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    private static SoundManagerScript instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType soundType, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)soundType], volume);
    }

    public static AudioClip GetSound(SoundType soundType)
    {
        return instance.soundList[(int)soundType];
    }
}
