using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientPlacer : MonoBehaviour
{
    public Action ClientPlaced;

    [SerializeField] private Button _placeButton;
    [SerializeField] private Transform _clientTransform;

    private void Start() => _placeButton.onClick.AddListener(PlaceClient);
    
    private void OnEnable() => ARPlaneRaycaster.PlaneRaycasted += OnPlaneRaycasteed;
    private void OnDisable() => ARPlaneRaycaster.PlaneRaycasted -= OnPlaneRaycasteed;

    public void PlaceClient()
    {
        _placeButton.gameObject.SetActive(false);
        enabled = false;
    }

    private void OnPlaneRaycasteed(Vector3 position) => _clientTransform.position = position;
}