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

    private void Start()
    {
        _screenButton.Clicked += _clientPlaser.PlaceClient;

        _clientPlaser.ClientPlaced += () =>
        {
            _screenButton.Clicked -= _clientPlaser.PlaceClient;
            _screenButton.Clicked += _cannon.Shoot;
        };

        _client.HealthEnds += Application.Unload;
        _client.ProjectileHitsClient += _progressBar.Fill;
    }
}