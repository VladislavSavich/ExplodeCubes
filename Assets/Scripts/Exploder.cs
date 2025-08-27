using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody explodableObject in rigidbodies)
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}
