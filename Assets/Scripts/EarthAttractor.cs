using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAttractor : MonoBehaviour
{
    private const float gravity = -100f;

    public void Attract(Transform body) {
        Vector3 targetDirection = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;
        body.rotation = Quaternion.FromToRotation(bodyUp, targetDirection) * body.rotation;
        body.GetComponent<Rigidbody>().AddForce(targetDirection * gravity);
    }

    public void RotateToEarth(Transform body) {
        Vector3 targetDirection = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;
        body.rotation = Quaternion.FromToRotation(bodyUp, targetDirection) * body.rotation;
    }
}
