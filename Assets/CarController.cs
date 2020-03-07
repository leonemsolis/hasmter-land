using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveDirection;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        moveDirection = new Vector3(0f, 0f, 1f);
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * 10f * Time.deltaTime);
    }
}
