using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    private static SoundEffects _instance;

    [SerializeField] private AudioSource _audioSource;
    
    [Header("Audio clips")]
    [SerializeField] private AudioClip _dartHits;
    [SerializeField] private AudioClip _tomatoHits;
    [SerializeField] private AudioClip _hit;

    private void Awake() => _instance = this;

    public static void PlayDartHitsSFX() => PlaySoundWitchRandomPitch(_instance._dartHits);
    public static void PlayTomatoHitsSFX() => PlaySoundWitchRandomPitch(_instance._tomatoHits);
    public static void PlayHitSFX() => PlaySoundWitchRandomPitch(_instance._hit);

    private static void PlaySoundWitchRandomPitch(AudioClip audioClip)
    {
        var randomValue = Random.Range(0.9f, 1.1f);

        _instance._audioSource.pitch = randomValue;
        _instance._audioSource.PlayOneShot(audioClip);
    }
}