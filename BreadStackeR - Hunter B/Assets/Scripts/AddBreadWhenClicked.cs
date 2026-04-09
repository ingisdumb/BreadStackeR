using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBreadWhenClicked : MonoBehaviour
{
    public int breadCount = 5;  // Bread available on this shelf   
    public PlayerInventory playerInventory;     // Assign PlayerInventory in Inspector

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
        if (breadCount > 0)
        {
            breadCount--;
            if (playerInventory != null)
            {
                playerInventory.AddBread();
            }

            Debug.Log(gameObject.name + " bread left: " + breadCount);

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