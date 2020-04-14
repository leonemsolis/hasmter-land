using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneStationButton : MonoBehaviour
{
    CloneStation cloneStation;

    private void Start() {
        cloneStation = FindObjectOfType<CloneStation>();
    }

    private void OnMouseDown() {
        cloneStation.Open();
    }
}
