using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public ovenBreadAmount OvenBreadAmount; // Reference to oven bread source

    // Player resource values
    public int bread = 0;
    public int money = 0;
    public int dough = 0;

    // UI Buttons
    public Button buyDoughButton;
    public Button buyMixerButton;

    // Item costs
    private int doughCost = 10;
    private int mixerCost = 50;

    void Start()
    {
        // Assign button click listeners
        if (buyDoughButton != null)
            buyDoughButton.onClick.AddListener(BuyDough);

        if (buyMixerButton != null)
            buyMixerButton.onClick.AddListener(BuyMixer);

        // Initialize bread from oven (if assigned)
        if (OvenBreadAmount != null)
            bread = OvenBreadAmount.breadAmount;
    }

    // Purchase dough if player has enough money
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

    // Purchase mixer if player has enough money
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

    // Add bread to inventory
    public void AddBread(int amount = 1)
    {
        bread += amount;
        Debug.Log("Player bread: " + bread);
    }

    // Remove bread if possible
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

    // Add or subtract money
    public void AddMoney(int amount)
    {
        money += amount;
        Debug.Log("Player money: $" + money);
    }

    // Add dough to inventory
    public void AddDough(int amount = 1)
    {
        dough += amount;
        Debug.Log("Player dough: " + dough);
    }
}