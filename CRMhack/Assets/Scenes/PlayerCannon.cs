using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannon : MonoBehaviour
{
    [Header("Templates")] 
    [SerializeField] private CannonProjectile _tomatoTemplate;

    [Header("Refs")]
    [SerializeField] private CannonButton _cannonButton;

    private void Start()
    {
        _cannonButton.ButtonReleased += OnCannonButtonRealesed;
        _cannonButton.enabled = false;
    }

    public void Enable() => _cannonButton.enabled = true;

    public void OnCannonButtonRealesed(float buttonHoldTime)
    {
        var projectile = Instantiate(_tomatoTemplate, transform.position, Quaternion.identity);

        var shotDirection = Camera.main.ViewportPointToRay(
            pos: new Vector2(0.5f, 0.5f), 
            eye: Camera.MonoOrStereoscopicEye.Mono).direction.normalized;

        projectile.AddForce(shotDirection, buttonHoldTime);
    }
}