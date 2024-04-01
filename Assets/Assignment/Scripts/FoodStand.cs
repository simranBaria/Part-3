using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodStand : Stand
{
    float time;
    public float initialTime;
    float countdown;
    public Slider slider;
    public TextMeshProUGUI timeText;
    public int timeLevel = 1, maxLevel = 25;

    // Start is called before the first frame update
    void Start()
    {
        SetProfit(initialProfit);
        SetTime(initialTime);
        SetCost(initialCost);
        DisplayText();
        DisplayCost();
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

    protected override void DisplayText()
    {
        base.DisplayText();
        timeText.text = string.Format("{0:F}", time) + "s";
    }

    // Method to set the time the stand takes to generate profit
    public void SetTime(float value)
    {
        time = value;
        slider.maxValue = time;
    }

    public void UpgradeTime()
    {
        if(timeLevel < maxLevel)
        {
            timeLevel++;
            SetTime(time -= initialTime / maxLevel);
            DisplayText();
        }
    }
}
