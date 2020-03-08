using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 moveAmount;
    Vector3 smoothVelocity;
    
    private const float velocity = 10f;
    private const float steering = 100f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * steering);      

        Vector3 moveDirection = new Vector3(0f, 0f, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 targetMoveAmount = moveDirection * velocity;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothVelocity, .15f);
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.deltaTime);
    }
}
