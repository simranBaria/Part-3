using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CharacterControl : MonoBehaviour
{
    public static Villager SelectedVillager { get; private set; }
    public TextMeshProUGUI selectedText;
    public static CharacterControl Instance;

    public void Start()
    {
        Instance = this;
    }

    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        Instance.selectedText.text = "Selected: " + villager.ToString();
    }

    private void Update()
    {
        /*if (SelectedVillager != null) selectedText.SetText("Selected: " + SelectedVillager.name);
        else selectedText.SetText("Selected: None");*/
    }
}
