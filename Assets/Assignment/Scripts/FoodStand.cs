using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodStand : Stand
{
    // Variables for the countdown
    float time, countdown;
    public float initialTime;
    public Slider slider;

    // Variables for upgrading time
    float timeCost;
    public TextMeshProUGUI timeText;
    public int timeLevel = 1, maxTimeLevel = 25;
    public Button timeButton;
    public TextMeshProUGUI timeCostText;
    public float initialTimeCost, timeGrowthRate;

    // Variables for buying the stand
    public GameObject UIDisplay, food;
    public Button buyButton;
    public TextMeshProUGUI buyText;
    public float buyCost;
    bool bought = false;
    public Animator animator;

    // Start is called before the first frame update
    protected override void Start()
    {
        // Call the base to set and display the profit
        base.Start();

        // Set and display the time
        SetTime(initialTime);
        SetTimeCost(initialTimeCost);
        DisplayCost(timeCost, timeCostText);

        // Don't display stand info until the stand is bought
        DisplayStand(false);

        // Display the buy cost
        buyText.text = "BUY: " + string.Format("{0:C}", buyCost);
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

    // Method to display text on the stand
    protected override void DisplayText()
    {
        // Call the base to display the profit text as well
        base.DisplayText();

        // Display the time
        timeText.text = string.Format("{0:F}", time) + "s";
    }

    // Method to set the time the stand takes to generate profit
    public void SetTime(float value)
    {
        time = value;

        // Set the timer to reflect the amount of time
        slider.maxValue = time;
    }

    // Method to upgrade time
    public void UpgradeTime()
    {
        // Only upgrade if the max level hasn't been reached
        if(timeLevel < maxTimeLevel)
        {
            Funds.UpdateFunds(-timeCost);

            // Upgrade time
            timeLevel++;
            SetTime(time -= initialTime / maxTimeLevel);
            DisplayText();

            // Show that the max level has been reached
            if (timeLevel == maxTimeLevel) ChangeButton(timeCostText, timeButton);
            else
            {
                // Set the cost of the next upgrade
                SetTimeCost(CalculateNextCost(timeLevel, timeGrowthRate, initialTimeCost));
                DisplayCost(timeCost, timeCostText);
            }
        }
    }

    // Override the main update
    protected override void Update()
    {
        // Check to disable the buy button if not bought
        // If bought then check to disable the upgrade buttons instead
        if(bought)
        {
            base.Update();

            // Disable the button to upgrade time if funds are lacking
            if (Funds.TotalFunds < timeCost && timeLevel != maxTimeLevel) timeButton.interactable = false;
            else timeButton.interactable = true;
        }
        else
        {
            // Disable the buy button if funds are lacking
            if (Funds.TotalFunds < buyCost) buyButton.interactable = false;
            else buyButton.interactable = true;
        }
    }

    // Method to set the cost of time upgrading time
    private void SetTimeCost(float value)
    {
        timeCost = value;
    }

    // Method to display the stand and buttons
    public void DisplayStand(bool display)
    {
        UIDisplay.SetActive(display);
        food.SetActive(display);
        profitButton.gameObject.SetActive(display);
        timeButton.gameObject.SetActive(display);
    }

    // Method to buy the stand
    public void BuyStand()
    {
        Funds.UpdateFunds(-buyCost);
        bought = true;

        // Display the stand
        buyButton.gameObject.SetActive(false);
        DisplayStand(true);
        DisplayText();

        // Play the buy animation
        animator.SetTrigger("Buy");

        // Start generating profit
        StartGenerating();
    }
}
