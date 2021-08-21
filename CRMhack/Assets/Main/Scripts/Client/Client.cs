using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public Action HealthEnds;
    public Action<int, int> ProjectileHitsClient;

    private int _maxHealth = 15;
    private int _currenHealth = 15;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<CannonProjectile>(out var projectile))
        {
            _currenHealth -= 1;

            if (_currenHealth <= 0)
                HealthEnds?.Invoke();

            ProjectileHitsClient?.Invoke(_maxHealth, _maxHealth - _currenHealth);
            
            projectile.OnHitClient();
        }
    }
}