using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Stand : MonoBehaviour
{
    float profit, profitCost;
    public float initialProfit, growthRate, initialCost;
    public TextMeshProUGUI nameText, profitText, profitCostText;
    public string standName;
    public int profitLevel = 1;
    public Button profitButton;

    // Method to add funds to the funds class
    public void AddFunds()
    {
        Funds.UpdateFunds(profit);
    }

    // Method to set the amount of profit the stand makes
    public void SetProfit(float value)
    {
        profit = value;
    }

    // Method to display text info on the stand
    protected virtual void DisplayText()
    {
        nameText.text = standName;
        profitText.text = string.Format("{0:C}", profit);
    }

    // Method to upgrade profit
    public void UpgradeProfit()
    {
        Funds.UpdateFunds(-profitCost);
        profitLevel++;
        SetProfit(initialProfit * profitLevel);
        DisplayText();
        CalculateNextCost();
    }

    private void Update()
    {
        if (Funds.TotalFunds < profitCost) profitButton.interactable = false;
        else profitButton.interactable = true;
    }

    public void SetCost(float value)
    {
        profitCost = value;
    }

    public void CalculateNextCost()
    {
        profitCost = initialCost * Mathf.Pow(growthRate, profitLevel);
        DisplayCost();
    }

    public void DisplayCost()
    {
        profitCostText.text = string.Format("{0:C}", profitCost);
    }
}
