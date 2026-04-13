using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositShelf : MonoBehaviour
{
    public PlayerInventory playerInventory; // Player inventory reference
    public int breadValue = 5;              // Money earned per bread

    void Start()
    {
        // Auto-find PlayerInventory if not assigned
        if (playerInventory == null)
        {
            playerInventory = FindObjectOfType<PlayerInventory>();
        }
    }

    // Called when this object is clicked
    void OnMouseDown()
    {
        if (playerInventory != null)
        {
            // Try to remove bread and reward money
            if (playerInventory.RemoveBread())
            {
                playerInventory.AddMoney(breadValue);
                Debug.Log("Sold bread for $" + breadValue);
            }
        }
    }
}