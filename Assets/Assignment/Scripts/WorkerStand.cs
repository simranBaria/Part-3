using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerStand : Stand
{
    public Animator animator;

    // Start is called before the first frame update
    //void Start()
    //{
    //    SetProfit(initialProfit);
    //    SetProfitCost(initialProfitCost);
    //    DisplayCost(profitCost, profitCostText);
    //    DisplayText();
    //}

    private void OnMouseDown()
    {
        // Play the click animation
        animator.SetTrigger("Clicked");

        // Add to funds
        AddFunds();
    }

    private void OnMouseEnter()
    {
        // Highlight the stand when the mouse hovers over
        animator.SetTrigger("Start Highlight");
    }

    private void OnMouseExit()
    {
        // Stop highlighting when the mouse stops hovering over
        animator.SetTrigger("Stop Highlight");
    }
}
