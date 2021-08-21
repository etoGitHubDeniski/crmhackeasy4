using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CannonProjectile : MonoBehaviour
{
    public void AddForce(Vector3 direction, float value)
    {
        GetComponent<Rigidbody>().AddForce(direction * value, ForceMode.Impulse);
    }
}