using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public Action HealthEnds;

    private int _health = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CannonProjectile>() is CannonProjectile projectile)
        {
            _health -= 1;

            if (_health <= 0)
            {
                HealthEnds?.Invoke();
                Destroy(projectile.gameObject);
            }
        }
    }
}