using DG.Tweening;
using System;
using UnityEngine;

public class ClientPlacer : MonoBehaviour
{
    public Action ClientPlaced;

    [SerializeField] private Transform _clientTransform;
    [Header("Materials")]
    [SerializeField] private Material _main;
    [SerializeField] private Material _red;
    [SerializeField] private Material _green;

    private MeshRenderer[] _meshRenderers;
    private Material _currentMaterial;

    private bool _placeEnabled;

    private void Awake()
    {
        _meshRenderers = _clientTransform.GetComponentsInChildren<MeshRenderer>();
    }

    private void OnEnable()
    {
        ARPlaneRaycaster.PlaneRaycasted += OnPlaneRaycasteed;
        ARPlaneRaycaster.PlaneNotRaycasted += OnPlaneNotRaycasted;
    }

    private void OnDisable()
    {
        ARPlaneRaycaster.PlaneRaycasted -= OnPlaneRaycasteed;
        ARPlaneRaycaster.PlaneNotRaycasted -= OnPlaneNotRaycasted;
    }

    public void PlaceClient()
    {
#if !UNITY_EDITOR
        if (!_placeEnabled)
            return;
#endif

        enabled = false;
        SetClientMaterial(_main);

        ClientPlaceAnimation();

        ClientPlaced?.Invoke();
    }

    private void ClientPlaceAnimation()
    {
        float baseScale = _clientTransform.localScale.x;
        
        _clientTransform.localScale = Vector3.zero;
        _clientTransform.DOScale(baseScale, 0.45f).SetEase(Ease.OutBack);
    }

    private void OnPlaneNotRaycasted()
    {
        _placeEnabled = false;
        SetClientMaterial(_red);
    }

    private void OnPlaneRaycasteed(Vector3 position, Vector3 rotation)
    {
        _placeEnabled = true;

        _clientTransform.position = position;
        _clientTransform.eulerAngles = new Vector3() { y = rotation.y };

        SetClientMaterial(_green);
    }

    private void SetClientMaterial(Material material)
    {
        if (_currentMaterial == material)
            return;

        _currentMaterial = material;

        foreach (var meshRenderer in _meshRenderers)
            meshRenderer.material = material;
    }
}