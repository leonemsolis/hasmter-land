using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveAmount;

    private const float velocity = 10f;
    private const float steering = 1f;

    private Path path;
    private PathNode target;
    private EarthAttractor earth;
    

    private void Start()
    {
        earth = FindObjectOfType<EarthAttractor>();
        rb = GetComponent<Rigidbody>();
        path = FindObjectOfType<Path>();
        target = path.GetNextPathNode();
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.deltaTime);
        earth.Attract(transform);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "node" && other.gameObject == target.gameObject) {
            target = path.GetNextPathNode();
        }
    }

    private void Update()
    {
        
        // if(Input.GetKey(KeyCode.W)) {
        //     transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * steering);      
        // } else if(Input.GetKey(KeyCode.S)) {
        //     transform.Rotate(Vector3.up * -Input.GetAxis("Horizontal") * Time.deltaTime * steering);      
        // }
        moveAmount = Vector3.forward * velocity;
        Vector3 direction = target.transform.position - transform.position;
        
        Debug.DrawRay(transform.position, direction, Color.red);
        Quaternion rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), .1f);
        transform.rotation = rotation;
        earth.RotateToEarth(transform);
    }
}
