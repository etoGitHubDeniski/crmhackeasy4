using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : CannonProjectile
{
    [SerializeField] private GameObject _hitParticles;

    public override void AddForce(Vector3 direction, float value)
    {
        base.AddForce(direction, value);

        GetComponent<Rigidbody>().angularVelocity = RandomVector();
        transform.rotation = RandomQuaternion();
    }

    public override void OnHitClient()
    {
        var particles = Instantiate(_hitParticles, transform.position, Quaternion.identity);
        
        DOVirtual.DelayedCall(1f, () => Destroy(particles));
        
        Destroy(gameObject);
    }
}
