using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToAttract : MonoBehaviour
{
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    public Rigidbody GetRigidbody() {
        return rb;
    }
}
