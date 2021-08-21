using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dart : CannonProjectile
{
    private Rigidbody _rigidbody;

    private bool _hitsClient = false;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void Update()
    {
        if (_hitsClient)
            transform.LookAt(transform.position + _rigidbody.velocity);
    }


    public override void OnHitClient()
    {
        HitAnimation();
        _rigidbody.isKinematic = true;
        Destroy(this);
    }

    private void HitAnimation()
    {
        transform.DOPunchRotation(new Vector3() { x = 30 }, 0.35f, 30);
    }
}
