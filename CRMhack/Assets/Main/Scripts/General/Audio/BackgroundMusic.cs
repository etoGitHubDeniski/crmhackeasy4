using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [Space]
    [SerializeField] private AudioClip[] _music;

    public void Play()
    {
        var baseVolume = _audioSource.volume;

        _audioSource.volume = 0;
        _audioSource.clip = _music.GetRandomObject();
        _audioSource.Play();

        _audioSource.DOFade(baseVolume, 3f).SetEase(Ease.InOutSine);
    }

    public void Stop()
    {
        _audioSource
            .DOFade(0, 2.5f).SetEase(Ease.InOutSine)
            .onComplete += _audioSource.Stop;
    }
}