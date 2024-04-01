using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Stand : MonoBehaviour
{
    // Name display
    public TextMeshProUGUI nameText;
    public string standName;

    // Variables for calculating and displaying the cost of upgrades
    public float profitCost;
    public float initialProfit, initialProfitCost, profitGrowthRate;
    public Button profitButton;
    public TextMeshProUGUI profitCostText;
    public Sprite maxButtonSprite;
    public Color maxColour;

    // Variables for upgrading profit
    public TextMeshProUGUI profitText;
    float profit;
    public int profitLevel = 1, maxProfitLevel = 25;

    protected virtual void Start()
    {
        // Set and display the profit
        SetProfit(initialProfit);
        SetProfitCost(initialProfitCost);
        DisplayCost(profitCost, profitCostText);
        DisplayText();
    }

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
    protected virtual void UpgradeProfit()
    {
        // Only upgrade if the max level hasn't been reached
        if(profitLevel < maxProfitLevel)
        {
            Funds.UpdateFunds(-profitCost);

            // Upgrade profit
            profitLevel++;
            SetProfit(initialProfit * profitLevel * 5);
            DisplayText();

            // Show that the max level has been reached
            if(profitLevel == maxProfitLevel) ChangeButton(profitCostText, profitButton);
            else
            {
                // Set the cost of the next upgrade
                SetProfitCost(CalculateNextCost(profitLevel, profitGrowthRate, initialProfitCost));
                DisplayCost(profitCost, profitCostText);
            }
        }
    }

    protected virtual void Update()
    {
        // Disable the button if funds are lacking
        if (Funds.TotalFunds < profitCost && profitLevel != maxProfitLevel) profitButton.interactable = false;
        else profitButton.interactable = true;
    }

    // Method to set the cost of the profit upgrade
    public void SetProfitCost(float value)
    {
        profitCost = value;
    }

    // Method to calculate the cost of an upgrade
    public float CalculateNextCost(float level, float growthRate, float initialCost)
    {
        return initialCost * Mathf.Pow(growthRate, level);
    }

    // Method to display the cost of an upgrade
    public void DisplayCost(float cost, TextMeshProUGUI textDisplay)
    {
        textDisplay.text = string.Format("{0:C}", cost);
    }

    // Method to change a button
    public void ChangeButton(TextMeshProUGUI textDisplay, Button button)
    {
        textDisplay.text = "MAX";
        textDisplay.color = maxColour;
        button.image.sprite = maxButtonSprite;
    }
}
