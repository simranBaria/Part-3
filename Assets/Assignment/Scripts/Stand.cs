using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stand : MonoBehaviour
{
    public float profit, time;
    float countdown = 0;
    public Slider slider;
    public TextMeshProUGUI nameText, profitText, timeText;
    public string standName;

    private void Start()
    {
        nameText.text = standName;
        SetTime(time);
        SetProfit(profit);
        DisplayText();
        StartGenerating();
    }

    // Method to start the coroutine for generating profit
    private void StartGenerating()
    {
        StartCoroutine(GenerateProfit());
    }

    // Coroutine to countdown the stand's time and generate its profit
    IEnumerator GenerateProfit()
    {
        // Check if the timer should still be ticking down
        while (countdown <= time)
        {
            countdown += Time.deltaTime;
            slider.value = countdown;
            yield return null;
        }

        // Add funds once the timer is done and start the coroutine again
        countdown = 0;
        AddFunds();
        StartGenerating();
    }

    // Method to add funds to the funds class
    public void AddFunds()
    {
        Funds.UpdateFunds(profit);
    }

    // Method to set the time the stand takes to generate profit
    public void SetTime(float value)
    {
        time = value;
        slider.maxValue = time;
    }

    // Method to set the amount of profit the stand makes
    public void SetProfit(float value)
    {
        profit = value;
    }

    // Method to display text info on the stand
    public void DisplayText()
    {
        profitText.text = string.Format("{0:C}", profit);
        timeText.text = time + "s";
    }
}
