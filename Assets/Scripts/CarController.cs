using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveDirection;
    float speed = 10f;
    Attractor earth;
    bool grounded = false;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        moveDirection = new Vector3(0f, 0f, 1f);

        earth = FindObjectOfType<Attractor>();
    }

    private void OnCollisionEnter(Collision other) {
        if(!grounded) {
            if(other.collider.tag == "earth") {
                rb.drag = 46f;
                grounded = true;
            }
        }
    }
    // private void Update() {
    //     if(grounded) {
    //         if(Input.GetKey(KeyCode.A)) {
    //             moveDirection = new Vector3(-1f, 0f, 1f);
    //         } else if(Input.GetKey(KeyCode.D)) {
    //             moveDirection = new Vector3(1f, 0f, 1f);
    //         } else {
    //             moveDirection = new Vector3(0f, 0f, 1f);
    //         }
    //         if(Input.GetKey(KeyCode.W)) {
    //             speed = 10f;
    //         } else {
    //             speed = 0f;
    //         }
    //     }
    // }
    private void FixedUpdate() {
        earth.Attract(rb);
        if(grounded) {
            rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        }
    }
}
