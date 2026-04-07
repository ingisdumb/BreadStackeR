using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int bread = 0;
    public int money = 0;

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
}