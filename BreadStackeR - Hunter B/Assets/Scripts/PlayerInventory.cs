using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public ovenBreadAmount OvenBreadAmount;
    // Player stats
    public int bread = 0;
    public int money = 0;
    public int dough = 0;

    // UI Buttons
    public Button buyDoughButton;
    public Button buyMixerButton;

    // Costs
    private int doughCost = 10;
    private int mixerCost = 50;

    void Start()
    {
        // Always add listeners to buttons
        if (buyDoughButton != null)
            buyDoughButton.onClick.AddListener(BuyDough);

        if (buyMixerButton != null)
            buyMixerButton.onClick.AddListener(BuyMixer);
        if (OvenBreadAmount != null)
            bread = OvenBreadAmount.breadAmount; // Start with random bread from oven
    }

    // --- Purchase Methods ---
    void BuyDough()
    {
        if (money >= doughCost)
        {
            AddDough(1);
            AddMoney(-doughCost);
            Debug.Log("Bought 1 dough!");
        }
        else
        {
            Debug.Log("Not enough money to buy dough!");
        }
    }

    void BuyMixer()
    {
        if (money >= mixerCost)
        {
            AddMoney(-mixerCost);
            Debug.Log("Mixer bought!");
        }
        else
        {
            Debug.Log("Not enough money to buy a mixer!");
        }
    }

    // --- Inventory Methods ---
    public void AddBread(int amount = 1)
    {
        bread += amount;
        Debug.Log("Player bread: " + bread);
    }

    public bool RemoveBread(int amount = 1)
    {
        if (bread >= amount)
        {
            bread -= amount;
            Debug.Log("Removed " + amount + " bread.");
            return true;
        }

        Debug.Log("Not enough bread!");
        return false;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        Debug.Log("Player money: $" + money);
    }

    public void AddDough(int amount = 1)
    {
        dough += amount;
        Debug.Log("Player dough: " + dough);
    }
}