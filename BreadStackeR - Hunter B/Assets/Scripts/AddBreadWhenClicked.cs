using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBreadWhenClicked : MonoBehaviour
{
    public int breadCount = 5;              // Bread available on this shelf
    public PlayerInventory playerInventory; // Reference to player inventory

    void Start()
    {
        // Auto-find PlayerInventory if not assigned
        if (playerInventory == null)
        {
            playerInventory = FindObjectOfType<PlayerInventory>();
        }
    }

    // Called when object is clicked
    void OnMouseDown()
    {
        if (breadCount > 0)
        {
            breadCount--;

            // Add bread to player
            if (playerInventory != null)
            {
                playerInventory.AddBread();
            }

            Debug.Log(gameObject.name + " bread left: " + breadCount);

            // Notify when empty
            if (breadCount == 0)
            {
                Debug.Log(gameObject.name + " is empty!");
            }
        }
        else
        {
            Debug.Log("Shelf is empty!");
        }
    }
}