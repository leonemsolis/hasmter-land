using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void Attract(Rigidbody rbToAttract) {
        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2f);
        Vector3 force = direction.normalized * forceMagnitude;
        rbToAttract.AddForce(force);
    }
}
