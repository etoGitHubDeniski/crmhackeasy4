using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProcess : MonoBehaviour
{
    [Header("Client")]
    [SerializeField] private Client _client;
    [SerializeField] private ClientPlacer _clientPlaser;
    [Header("Cannon")]
    [SerializeField] private Cannon _cannon;
    [Header("Screen button")]
    [SerializeField] private ScreenButton _screenButton;
    [Header("UI")]
    [SerializeField] private ProgressBar _progressBar;
    [Header("Screen overlay")]
    [SerializeField] private ScreenOverlay _screenOverlay;
    [Header("Background music player")]
    [SerializeField] private BackgroundMusic _backgroundMusic;


    private void Start()
    {
        _screenButton.Clicked += _clientPlaser.PlaceClient;

        _clientPlaser.ClientPlaced += () =>
        {
            _screenButton.Clicked -= _clientPlaser.PlaceClient;
            _screenButton.Clicked += _cannon.Shoot;
        };

        _client.HealthEnds += () =>
        {
            _screenButton.Clicked -= _cannon.Shoot;

            _backgroundMusic.Stop();

            DOTween.Sequence()
                .Append(_screenOverlay.ShowOverlay())
                .Append(_screenOverlay.ShowText("Надеюсь, вам стало легче"))
                .AppendCallback(Application.Unload);
        };

        _client.ProjectileHitsClient += _progressBar.Fill;

        DOTween.Sequence()
            .SetId(transform)
            .Append(_screenOverlay.ShowText("Расслабьтесь"))
            .AppendCallback(_backgroundMusic.Play)
            .Append(_screenOverlay.HideOverlay());
    }
}