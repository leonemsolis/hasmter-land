using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusBar : MonoBehaviour
{
    private float speed;
    private float total;
    private float available;

    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI totalText;
    [SerializeField] TextMeshProUGUI availableText;

    void Start()
    {
        speed = 0.1f;
        total = 2f;
        available = 0f;
    }


    void Update()
    {
        available += speed * Time.deltaTime;
        SetAllText();   
    }

    private void SetAllText()
    {
        speedText.SetText(speed.ToString("F1") + " / S");
        totalText.SetText(Mathf.Floor(total)+"");
        availableText.SetText(Mathf.Floor(available) + "");
    }

    public bool UpgradeCloneMachine(float cost, float upgradedSpeed) {
        if(cost <= available) {
            available -= cost;
            total += cost;
            speed = upgradedSpeed;
            return true;
        }
        return false;
    }

    public float GetCurrentSpeed() {
        return speed;
    }
}
