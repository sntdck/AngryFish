using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicGrass : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float tiltAngle = 50f;
            transform.Rotate(Vector3.forward, tiltAngle);
        }
    }
}
