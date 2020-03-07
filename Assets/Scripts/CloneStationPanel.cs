using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CloneStationPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] TextMeshProUGUI nextSpeedText;
    [SerializeField] TextMeshProUGUI currentSpeedText;
    [SerializeField] TextMeshProUGUI currentLevelText;

    CanvasGroup thisGroup;
    StatusBar statusBar;

    int nextLevel = 2;
    float cost = 2f;
    float nextSpeed = .2f;

    void Start()
    {
        thisGroup = GetComponent<CanvasGroup>();  
        statusBar = FindObjectOfType<StatusBar>();
        Close();
    }

    public void Open() {
        thisGroup.alpha = 1f;
        thisGroup.blocksRaycasts = true;
    }

    public void Close() {
        thisGroup.alpha = 0f;
        thisGroup.blocksRaycasts = false;
    }

    public void Upgrade() {
        if(statusBar.UpgradeCloneMachine(cost, nextSpeed)) {
            currentLevelText.SetText("LEVEL "+nextLevel);
            nextLevel++;
            cost = Mathf.Pow(nextLevel + 9, 2) / 35f;
            costText.SetText(Mathf.Ceil(cost).ToString());
            nextSpeed = nextLevel * .1f;
            nextSpeedText.SetText(System.Math.Round(nextSpeed, 2).ToString() + "/ S");
            currentSpeedText.SetText(System.Math.Round(statusBar.GetCurrentSpeed(), 2).ToString()+" / S");
        }
    }
}
