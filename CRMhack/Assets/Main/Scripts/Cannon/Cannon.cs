using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private CannonProjectile[] _projectileTemplates;

    public void Shoot()
    {
        var projectile = Instantiate(_projectileTemplates.GetRandomObject(), transform.position, Quaternion.identity);

        var shotDirection = Camera.main.ViewportPointToRay(
            pos: new Vector2(0.5f, 0.5f), 
            eye: Camera.MonoOrStereoscopicEye.Mono).direction.normalized;

        var force = 10f;

        projectile.AddForce(shotDirection, force);
    }
}