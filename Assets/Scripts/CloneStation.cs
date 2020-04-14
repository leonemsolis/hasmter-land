using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneStation : MonoBehaviour
{

    [SerializeField] private Transform cameraPosition;
    private Vector3 originPosition;
    private Quaternion originRotation;
    private Camera cam;

    private void Start() {
        cam = Camera.main;
    }

    public void Open() {
        FindObjectOfType<CloneStationPanel>().Open();
        originPosition = cam.transform.position;
        originRotation = cam.transform.rotation;
        cam.transform.position = cameraPosition.position;
        cam.transform.rotation = cameraPosition.rotation;
    }

    public void Close() {
        FindObjectOfType<CloneStationPanel>().Close();
        cam.transform.position = originPosition;
        cam.transform.rotation = originRotation;
    }
}
