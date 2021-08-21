using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class CannonProjectile : MonoBehaviour
{
    public virtual void AddForce(Vector3 direction, float value)
    {
        GetComponent<Rigidbody>().AddForce(direction * value, ForceMode.Impulse);
    }

    public abstract void OnHitClient();

    protected Quaternion RandomQuaternion() => new Quaternion()
    {
        x = Random.Range(-1, 1f),
        y = Random.Range(-1, 1f),
        z = Random.Range(-1, 1f),
        w = Random.Range(-1, 1f)
    };

    protected Vector3 RandomVector() => new Vector3()
    {
        x = Random.Range(0, 100f),
        y = Random.Range(0, 100f),
        z = Random.Range(0, 100f)
    };
}