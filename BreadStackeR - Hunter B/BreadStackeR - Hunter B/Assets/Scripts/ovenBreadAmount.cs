using UnityEngine;

public class ovenBreadAmount : MonoBehaviour
{
    public int breadAmount = 1; // Current bread stored in this shelf
    public int maxBreadAmount = 5; // Maximum bread this shelf can hold

    void Awake()
    {
        breadAmount = Mathf.Clamp(breadAmount, 0, maxBreadAmount);
    }

    public bool TakeBread(int amount = 1)
    {
        if (amount <= 0 || breadAmount < amount)
        {
            return false;
        }

        breadAmount -= amount;
        Debug.Log(gameObject.name + " bread left: " + breadAmount);
        return true;
    }

    public bool AddBread(int amount = 1)
    {
        if (amount <= 0)
        {
            return false;
        }

        int spaceRemaining = maxBreadAmount - breadAmount;
        if (spaceRemaining <= 0)
        {
            Debug.Log(gameObject.name + " is full!");
            return false;
        }

        int amountAdded = Mathf.Min(amount, spaceRemaining);
        breadAmount += amountAdded;
        Debug.Log(gameObject.name + " bread restocked to: " + breadAmount);
        return amountAdded > 0;
    }

    public bool HasBread()
    {
        return breadAmount > 0;
    }

    public bool HasRoom()
    {
        return breadAmount < maxBreadAmount;
    }
}
