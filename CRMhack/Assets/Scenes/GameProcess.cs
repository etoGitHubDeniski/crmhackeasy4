using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProcess : MonoBehaviour
{
    [SerializeField] private ClientPlacer _clientPlaser;
    [SerializeField] private Cannon _cannon;
    [SerializeField] private Client _client;


    private void Start()
    {
        _clientPlaser.ClientPlaced += _cannon.Enable;
        _client.HealthEnds += Application.Unload;
    }
}