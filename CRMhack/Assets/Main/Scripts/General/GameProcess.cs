using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProcess : MonoBehaviour
{
    [SerializeField] private ClientPlacer _clientPlaser;
    [SerializeField] private Cannon _cannon;
    [SerializeField] private Client _client;
    [SerializeField] private ScreenButton _screenButton;


    private void Start()
    {
        _screenButton.Clicked += _clientPlaser.PlaceClient;
        
        _clientPlaser.ClientPlaced += () =>
        {
            _screenButton.Clicked -= _clientPlaser.PlaceClient;
            _screenButton.Clicked += _cannon.Shoot;
        };

        _client.HealthEnds += Application.Unload;
    }
}