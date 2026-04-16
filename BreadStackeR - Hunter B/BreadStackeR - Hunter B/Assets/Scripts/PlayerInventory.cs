using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public Button depositDoughButton;

    // Player resource values
    public int bread = 0;
    public int money = 0;
    public int dough = 0;

    // UI Buttons
    public Button buyDoughButton;
    public Button buyMixerButton;
    public Button takeBreadButton;
    public Button sellBreadButton;

    // Item costs
    private int doughCost = 10;
    private int mixerCost = 50;

    //Bread Sell Price
    private int breadSell = 10;

    private ovenBreadAmount selectedStorage;
    private OvenBaker selectedOven;

    //Button Listeners
    void Start()
    {
        if (depositDoughButton == null)
        {
            depositDoughButton = FindButtonByName("Deposit Dough");
        }

        // Assign button click listeners
        if (buyDoughButton != null)
            buyDoughButton.onClick.AddListener(BuyDough);

        if (buyMixerButton != null)
            buyMixerButton.onClick.AddListener(BuyMixer);
        
        if (takeBreadButton != null)
            takeBreadButton.onClick.AddListener(TakeBreadFromSelectedShelf);

        if (depositDoughButton != null)
            depositDoughButton.onClick.AddListener(DepositDoughToSelectedShelf);
        
        if (sellBreadButton != null)
        {
            sellBreadButton.onClick.AddListener(SellBread);
        }
            
    }

    void Update()
    {
        if (takeBreadButton != null)
        {
            takeBreadButton.interactable = selectedStorage != null && selectedStorage.HasBread();
        }

        if (depositDoughButton != null)
        {
            depositDoughButton.interactable = selectedOven != null && dough > 0 && selectedStorage == null;
        }
    }

    //New Sell logic
    void SellBread()
    {
        if (bread > 0)
        {
            RemoveBread(1);
            AddMoney(breadSell);
        }
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

    void TakeBreadFromSelectedShelf()
    {
        Debug.Log("Attempting take bread. Storage selected: " + (selectedStorage != null ? selectedStorage.gameObject.name : "null"));

        if (selectedStorage == null)
        {
            Debug.Log("No shelf selected.");
            return;
        }

        if (selectedStorage.TakeBread())
        {
            Debug.Log("Took bread successfully.");
            AddBread(1);
        }
        else
        {
            Debug.Log("Shelf is empty!");
        }
    }

    void DepositDoughToSelectedShelf()
    {
        Debug.Log("Attempting deposit. Oven: " + (selectedOven != null ? selectedOven.gameObject.name : "null") + " Storage: " + (selectedStorage != null ? selectedStorage.gameObject.name : "null"));

        if (selectedStorage != null)
        {
            Debug.Log("Invalid selection: cannot deposit while storage is selected.");
            return;
        }

        if (selectedOven == null)
        {
            Debug.Log("No oven selected.");
            return;
        }

        if (dough <= 0)
        {
            Debug.Log("Not enough dough!");
            return;
        }

        if (RemoveDough(1))
        {
            Debug.Log("Deposited dough to oven.");
            selectedOven.AddDough(1);
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

    public bool RemoveDough(int amount = 1)
    {
        if (dough >= amount)
        {
            dough -= amount;
            Debug.Log("Removed " + amount + " dough.");
            return true;
        }

        Debug.Log("Not enough dough!");
        return false;
    }

    public void SetSelectedStorage(ovenBreadAmount shelf)
    {
        Debug.Log("Selected storage: " + (shelf != null ? shelf.gameObject.name : "null"));
        selectedStorage = shelf;
    }

    public void ClearSelectedStorage(ovenBreadAmount shelf)
    {
        if (selectedStorage == shelf)
        {
            Debug.Log("Cleared storage selection: " + shelf.gameObject.name);
            selectedStorage = null;
        }
    }

    public void SetSelectedOven(OvenBaker oven)
    {
        Debug.Log("Selected oven: " + (oven != null ? oven.gameObject.name : "null"));
        selectedOven = oven;
    }

    public void ClearSelectedOven(OvenBaker oven)
    {
        if (selectedOven == oven)
        {
            Debug.Log("Cleared oven selection: " + oven.gameObject.name);
            selectedOven = null;
        }
    }

    // TEMP compatibility for old scripts (SelectableBread, etc.)
    public void SetSelectedShelf(ovenBreadAmount shelf)
    {
        SetSelectedStorage(shelf);
    }

    public void ClearSelectedShelf(ovenBreadAmount shelf)
    {
        ClearSelectedStorage(shelf);
    }

    Button FindButtonByName(string buttonName)
    {
        Button[] buttons = Resources.FindObjectsOfTypeAll<Button>();
        foreach (Button button in buttons)
        {
            if (button.name == buttonName && button.gameObject.scene.IsValid())
            {
                return button;
            }
        }

        return null;
    }
}
