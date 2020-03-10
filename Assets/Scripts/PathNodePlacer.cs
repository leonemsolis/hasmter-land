using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PathNodePlacer : MonoBehaviour
{
    void Update()
    {
        Transform earth = FindObjectOfType<EarthAttractor>().transform;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, earth.position - transform.position, out hit)) {
            Debug.DrawRay(transform.position, (earth.position - transform.position));
            float lastY = transform.localRotation.eulerAngles.y;
            transform.position = hit.point;
            transform.up = transform.position.normalized;
        }       
    }
}
