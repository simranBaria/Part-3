using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerStand : Stand
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        DisplayText();
    }

    private void OnMouseDown()
    {
        Debug.Log("clicked");
        animator.SetTrigger("Clicked");
        AddFunds();
    }

    private void OnMouseEnter()
    {
        animator.SetTrigger("Start Highlight");
    }

    private void OnMouseExit()
    {
        animator.SetTrigger("Stop Highlight");
    }
}
