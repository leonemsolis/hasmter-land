using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    private Vector3 lastMousePosition = Vector3.zero;
    private Vector3 mousePositionDelta = Vector3.zero;

    [SerializeField] float ROTATE_SPEED = 50f;
    private const float ZOOM_MAX = -0.696f;
    private const float ZOOM_MIN = -1.308f;

    private void Update()
    {
        Zoom();
    }


    private void OnMouseDrag()
    {
        float rotationX = Input.GetAxis("Mouse X") * ROTATE_SPEED * Mathf.Deg2Rad;
        float rotationY = Input.GetAxis("Mouse Y") * ROTATE_SPEED * Mathf.Deg2Rad;

        transform.Rotate(Camera.main.transform.up, -rotationX, Space.World);
        transform.Rotate(Camera.main.transform.right, rotationY, Space.World);
    }

    private void Zoom()
    {
        float value = 0;
#if UNITY_EDITOR
        value = Input.GetAxis("Mouse ScrollWheel");
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
            value = distance * 0.01f;
        }
#endif
        if (value > 0)
        {
            if (Camera.main.transform.localPosition.z > ZOOM_MAX)
            {
                return;
            }
        }
        else
        {
            if (Camera.main.transform.localPosition.z < ZOOM_MIN)
            {
                return;
            }
        }
        Camera.main.transform.localPosition += new Vector3(0f, 0f, value);
    }
}
