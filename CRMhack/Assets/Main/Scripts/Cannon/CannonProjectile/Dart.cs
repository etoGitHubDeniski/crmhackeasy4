using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //anim
        Destroy(_rigidbody);
        Destroy(this);
    }
}
