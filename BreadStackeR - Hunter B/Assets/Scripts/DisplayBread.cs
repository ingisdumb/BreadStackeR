using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayBread : MonoBehaviour
{
    // UI text references
    public TMP_Text breadText;
    public TMP_Text moniesText;
    public TMP_Text doughText;

    public PlayerInventory playerInventory; // Reference to player data

    void Update()
    {
        // Update UI every frame with current values
        breadText.text = "Bread: " + playerInventory.bread.ToString();
        moniesText.text = "Monies: " + playerInventory.money.ToString();
        doughText.text = "Dough: " + playerInventory.dough.ToString();
    }
}