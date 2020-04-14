using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CloneStationPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] TextMeshProUGUI productionText;
    [SerializeField] TextMeshProUGUI currentSpeedText;
    [SerializeField] TextMeshProUGUI currentLevelText;

    CanvasGroup thisGroup;
    StatusBar statusBar;

    int currentLevel = 1;

    float cost;
    private const float BASE_COST = 20f;
    private const float BASE_COST_MULT = 1.05f;
    
    float production;
    private const float BASE_PROD = 1.2f;
    private const float BASE_PROD_MULT = 1.1f;

    void Start()
    {
        CalculateCost();
        CalculateProduction();   
        thisGroup = GetComponent<CanvasGroup>();  
        statusBar = FindObjectOfType<StatusBar>();
        Close();
    }

    private void CalculateCost() {
        cost = BASE_COST * Mathf.Pow(BASE_COST_MULT, currentLevel);
    }

    private void CalculateProduction() {
        production = BASE_PROD * BASE_PROD_MULT * currentLevel;
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
        if(statusBar.UpgradeCloneMachine(cost, production)) {
            currentLevelText.SetText("LEVEL "+currentLevel);
            currentLevel++;
            cost = Mathf.Pow(currentLevel + 9, 2) / 35f;
            costText.SetText(Mathf.Ceil(cost).ToString());
            production = currentLevel * .1f;
            productionText.SetText(System.Math.Round(production, 2).ToString() + "/ S");
            currentSpeedText.SetText(System.Math.Round(statusBar.GetCurrentSpeed(), 2).ToString()+" / S");
        }
    }
}
