using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProcess : MonoBehaviour
{
    [Header("Client")]
    [SerializeField] private ClientPlacer _clientPlaser;
    [Header("Cannon")]
    [SerializeField] private PlayerCannon _cannon;


    private void Start()
    {
        _clientPlaser.ClientPlaced += _cannon.Enable;
    }
}
