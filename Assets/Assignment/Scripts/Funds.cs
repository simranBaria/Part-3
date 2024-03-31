using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Funds : MonoBehaviour
{
    public TextMeshProUGUI display;
    private float funds = 0;

    private void Start()
    {
        UpdateFunds(5420.9f);
    }

    // Method to update current funds
    public void UpdateFunds(float value)
    {
        funds += value;
        UpdateText();
    }

    // Method to update the display text
    private void UpdateText()
    {
        // Format for currency
        string text = string.Format("{0:C}", funds);
        text = text.Substring(1);

        // Add any zeroes needed at the start
        string zeroes = "000,000.00";
        text = zeroes.Substring(0, zeroes.Length - text.Length) + text;

        display.text = text;
    }
}
