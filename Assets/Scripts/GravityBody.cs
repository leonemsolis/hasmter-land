using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    private EarthAttractor earth;
    
    private void Start()
    {
        earth = FindObjectOfType<EarthAttractor>();
    }

    private void LateUpdate() {
        earth.Attract(transform);
    }
}
