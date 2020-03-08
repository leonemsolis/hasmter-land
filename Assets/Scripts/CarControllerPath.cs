using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerPath : MonoBehaviour
{
    Transform earth;
    bool grounded = false;

    void Start()
    {
        earth = FindObjectOfType<EarthController>().transform;
        StartCoroutine(StartMovement());
    }

    IEnumerator StartMovement() {
        yield return new WaitForSeconds(2f);
        grounded = true;
    }

    void FixedUpdate()
    {
        // Gravity
        RaycastHit hit;
        if(Physics.Raycast(transform.position, earth.position - transform.position, out hit)) {
            Debug.DrawRay(transform.position, (earth.position - transform.position));
            float lastY = transform.localRotation.eulerAngles.y;
            transform.position = hit.point;
            transform.up = transform.position.normalized;
        }
        // Movement
        if(grounded) {
            transform.position += 30f * Time.deltaTime * transform.TransformDirection(Vector3.forward);
        }
    }
}
