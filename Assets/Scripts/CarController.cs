using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 moveAmount;

    private const float velocity = 10f;
    private const float steering = 100f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * steering);      
        }

        moveAmount = new Vector3(0f, 0f, Input.GetAxis("Vertical")).normalized * velocity;
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.deltaTime);
    }
}
