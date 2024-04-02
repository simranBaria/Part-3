using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Funds : MonoBehaviour
{
    public static float TotalFunds { get; private set; }
    public static Funds Instance;

    public TextMeshProUGUI display;
    static string fundsText = "000,000.000";

    // Variables for displaying that the goal was met
    public Color boxColour, textColour;
    Image box;
    bool goalMet = false;

    private void Start()
    {
        // Initialize
        TotalFunds = 0;
        Instance = this;
    }

    // Method to update current funds
    public static void UpdateFunds(float value)
    {
        TotalFunds += value;
        if (TotalFunds >= 100000) Instance.GoalMet();
        UpdateText();
    }

    // Method to update the display text
    private static void UpdateText()
    {
        // Format for currency
        string formatted = string.Format("{0:N}", TotalFunds);

        // Add any zeroes needed at the start
        string zeroes = "000,000.00";
        if (formatted.Length < zeroes.Length) fundsText = zeroes.Substring(0, zeroes.Length - formatted.Length) + formatted;
        else fundsText = formatted;

        // Display
        Instance.display.text = fundsText;
    }

    // Method to display the goal being met
    public void GoalMet()
    {
        box = GetComponent<Image>();
        box.color = boxColour;
        display.color = textColour;
        goalMet = true;
    }

    // Method to send the player to the win screen
    public void Win()
    {
        if(goalMet) SceneCycling.NextScene();
    }
}
