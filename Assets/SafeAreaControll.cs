using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaControll : MonoBehaviour
{
    enum Position { TOP, BOTTOM };

    [SerializeField] Position position = Position.TOP;

    void Start()
    {
        float widthRatio = Screen.width / 640f;
        if (position == Position.TOP)
        {
            float notchHeight = Screen.height - Screen.safeArea.yMax;
            transform.localPosition -= new Vector3(0f, notchHeight / widthRatio, 0f);
        }
        else
        {

        }
    }
}
