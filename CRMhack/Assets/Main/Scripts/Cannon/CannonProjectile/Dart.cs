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
        if (!_hitsClient)
            transform.LookAt(transform.position + _rigidbody.velocity * 10);
    }


    public override void OnHitClient()
    {
        _hitsClient = true;
        _rigidbody.isKinematic = true;

        GetComponent<Collider>().enabled = false;
        
        HitAnimation();

        SoundEffects.PlayDartHitsSFX();

        Destroy(this);
    }

    private void HitAnimation() => transform.DOPunchRotation(new Vector3() { x = 30 }, 0.35f, 30);
}
