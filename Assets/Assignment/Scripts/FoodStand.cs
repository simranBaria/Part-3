using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodStand : Stand
{
    public float time;
    float countdown;
    public Slider slider;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        SetTime(time);
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

    protected override void DisplayText()
    {
        base.DisplayText();
        timeText.text = time + "s";
    }

    // Method to set the time the stand takes to generate profit
    public void SetTime(float value)
    {
        time = value;
        slider.maxValue = time;
    }
}
