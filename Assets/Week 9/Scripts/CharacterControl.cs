using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class CharacterControl : MonoBehaviour
{
    public static Villager SelectedVillager { get; private set; }
    public TextMeshProUGUI selectedText;
    public static CharacterControl Instance;
    public TMP_Dropdown dropdown;
    public Villager[] villagers = new Villager[3];
    float size;

    public void Start()
    {
        Instance = this;
        size = 1;
    }

    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        Instance.selectedText.text = "Selected: " + villager.name;
    }

    private void Update()
    {
        if(SelectedVillager != null)
        {
            if (SelectedVillager.movement.x > 0)
            {
                SelectedVillager.transform.localScale = new Vector2(-size, size);
            }
            else if (SelectedVillager.movement.x < 0)
            {
                SelectedVillager.transform.localScale = new Vector2(size, size);
            }
        }
    }

    public void ChangeVillager(Int32 selected)
    {
        for(int i = 0; i < villagers.Length; i++)
        {
            if (dropdown.options[selected].text == villagers[i].name) SetSelectedVillager(villagers[i]);
        }
    }

    public void SetSize(Single scale)
    {
        size = scale;
    }
}
