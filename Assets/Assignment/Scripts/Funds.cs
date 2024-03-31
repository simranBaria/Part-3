using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Funds : MonoBehaviour
{
    public TextMeshProUGUI display;
    private static float funds;
    static string fundsText = "000,000.000";
    public static Funds Instance;

    private void Start()
    {
        funds = 0;
        Instance = this;
    }

    // Method to update current funds
    public static void UpdateFunds(float value)
    {
        funds += value;
        UpdateText();
    }

    // Method to update the display text
    private static void UpdateText()
    {
        // Format for currency
        string formatted = string.Format("{0:N}", funds);

        // Add any zeroes needed at the start
        string zeroes = "000,000.00";
        fundsText = zeroes.Substring(0, zeroes.Length - formatted.Length) + formatted;
        Instance.display.text = fundsText;
    }
}
