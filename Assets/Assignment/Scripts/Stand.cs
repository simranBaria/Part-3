using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stand : MonoBehaviour
{
    public float profit;
    public TextMeshProUGUI nameText, profitText;
    public string standName;

    void Start()
    {
        SetProfit(profit);
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
}
