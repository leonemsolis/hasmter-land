using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    private Vector3 lastMousePosition = Vector3.zero;
    private Vector3 mousePositionDelta = Vector3.zero;

    float ROTATE_SPEED = 70f;
    const float ZOOM_MAX = 140f;
    const float ZOOM_MIN = 68f;
    bool lockMovement = false;
    
    private Transform cam;

    private void Start() {
        cam = Camera.main.transform;
        Vector3 targetDirection = (cam.position - transform.position).normalized;
        Vector3 camForward = -cam.forward;
        cam.rotation = Quaternion.FromToRotation(camForward, targetDirection) * cam.rotation;
    }

    private void Update()
    {
        if(Input.touchCount > 1) {
            foreach(Touch t in Input.touches) {
                if(t.phase == TouchPhase.Ended) {
                    lockMovement = true;
                }
            }
        }
        Zoom();
    }

    private void OnMouseDrag()
    {   
        if(lockMovement) {
            lockMovement = false;
            return;
        }
        if(Input.touchCount < 2) {
            float rotationX = Input.GetAxis("Mouse X") * ROTATE_SPEED * Mathf.Deg2Rad;
            float rotationY = Input.GetAxis("Mouse Y") * ROTATE_SPEED * Mathf.Deg2Rad;
            cam.RotateAround(transform.position, cam.up, rotationX);
            cam.RotateAround(transform.position, cam.right, -rotationY);
            // transform.Rotate(Camera.main.transform.up, -rotationX, Space.World);
            // transform.Rotate(Camera.main.transform.right, rotationY, Space.World);
        }
    }

    private void Zoom()
    {
        Debug.Log(Vector3.Distance(transform.position, cam.position));
        float zoomValue = 0;
#if UNITY_EDITOR
        zoomValue = Input.GetAxis("Mouse ScrollWheel") * 3f;
#else
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPosition = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPosition = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPosition - touchOnePrevPosition).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float distance = currentMagnitude - prevMagnitude;
            zoomValue = distance * 0.07f;
        }
#endif
        if (zoomValue < 0)
        {
            if (Vector3.Distance(transform.position, cam.position) > ZOOM_MAX)
            {
                return;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, cam.position) < ZOOM_MIN)
            {
                return;
            }
        }
        // cam.localPosition += new Vector3(0f, 0f, zoomValue);
        cam.position += cam.forward * zoomValue;
        
    }
}
