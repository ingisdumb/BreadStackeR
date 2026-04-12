using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyCanvasDisplay : MonoBehaviour
{
    public TMP_Text moniesText;             // UI text for money
    public PlayerInventory playerInventory; // Reference to player data

    void Update()
    {
        // Update money display in buy UI
        moniesText.text = "Monies: " + playerInventory.money.ToString();
    }
}