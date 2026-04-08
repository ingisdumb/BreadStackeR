using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositShelf : MonoBehaviour
{
    public PlayerInventory playerInventory;  // Assign PlayerInventory in Inspector
    public int breadValue = 5;               // Money per bread

    void Start()
    {
        // Optional: auto-find player inventory if not assigned
        if (playerInventory == null)
        {
            playerInventory = FindObjectOfType<PlayerInventory>();
        }
    }

    void OnMouseDown()
    {
        if (playerInventory != null)
        {
            if (playerInventory.RemoveBread())
            {
                playerInventory.AddMoney(breadValue);
                Debug.Log("Sold bread for $" + breadValue);
            }
        }
    }
}