using UnityEngine;

public class ovenBreadAmount : MonoBehaviour
{
    public int breadAmount = 1; // Current bread stored in this shelf
    public int maxBreadAmount = 5; // Maximum bread this shelf can hold

    void Awake()
    {
        breadAmount = Mathf.Clamp(breadAmount, 0, maxBreadAmount);
        Debug.Log(gameObject.name + " initialized with bread: " + breadAmount + "/" + maxBreadAmount);
    }

    public bool TakeBread(int amount = 1)
    {
        Debug.Log(gameObject.name + " attempting TakeBread: " + amount + " (current: " + breadAmount + ")");
        if (amount <= 0 || breadAmount < amount)
        {
            Debug.Log(gameObject.name + " TakeBread FAILED (not enough bread)");
            return false;
        }

        breadAmount -= amount;
        Debug.Log(gameObject.name + " TakeBread SUCCESS new amount: " + breadAmount);
        Debug.Log(gameObject.name + " bread left: " + breadAmount);
        return true;
    }

    public bool AddBread(int amount = 1)
    {
        Debug.Log(gameObject.name + " attempting AddBread: " + amount + " (current: " + breadAmount + ")");
        Debug.Log(gameObject.name + " space remaining: " + (maxBreadAmount - breadAmount));
        if (amount <= 0)
        {
            return false;
        }

        int spaceRemaining = maxBreadAmount - breadAmount;
        if (spaceRemaining <= 0)
        {
            Debug.Log(gameObject.name + " AddBread FAILED (shelf full)");
            Debug.Log(gameObject.name + " is full!");
            return false;
        }

        int amountAdded = Mathf.Min(amount, spaceRemaining);
        Debug.Log(gameObject.name + " AddBread adding: " + amountAdded);
        breadAmount += amountAdded;
        Debug.Log(gameObject.name + " AddBread SUCCESS new amount: " + breadAmount);
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
