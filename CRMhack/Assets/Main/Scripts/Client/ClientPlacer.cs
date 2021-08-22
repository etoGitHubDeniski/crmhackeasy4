using System;
using UnityEngine;

public class ClientPlacer : MonoBehaviour
{
    public Action ClientPlaced;

    [SerializeField] private Transform _clientTransform;

    private void OnEnable() => ARPlaneRaycaster.PlaneRaycasted += OnPlaneRaycasteed;
    private void OnDisable() => ARPlaneRaycaster.PlaneRaycasted -= OnPlaneRaycasteed;

    public void PlaceClient()
    {
        enabled = false;
        ClientPlaced?.Invoke();
    }

    private void OnPlaneRaycasteed(Vector3 position, Vector3 rotation)
    {
        _clientTransform.position = position;
        _clientTransform.eulerAngles = new Vector3() { y = rotation.y };
    }
}