using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

/// <summary>
/// Clickable shelf object that gives bread to the player.
/// </summary>
public class AddBreadWhenClicked : MonoBehaviour
{
    [Header("Shelf Settings")]
    [SerializeField] private int breadCount = 5;

    [Header("References")]
    [SerializeField] private PlayerInventory playerInventory;

    private void Start()
    {
        // Auto-find PlayerInventory if it is not assigned.
        if (playerInventory == null)
        {
            playerInventory = FindObjectOfType<PlayerInventory>();
        }
    }

    private void OnMouseDown()
    {
        if (breadCount <= 0)
        {
            Debug.Log("Shelf is empty!");
            return;
        }

        breadCount--;

        if (playerInventory != null)
        {
            playerInventory.AddBread(1);
        }
        else
        {
            Debug.LogWarning("PlayerInventory reference is missing.");
        }

        Debug.Log($"{gameObject.name} bread left: {breadCount}");

        if (breadCount == 0)
        {
            Debug.Log($"{gameObject.name} is empty!");
        }
    }
}