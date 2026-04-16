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

    private ovenBreadAmount selectedShelf;

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
            takeBreadButton.interactable = selectedShelf != null && selectedShelf.HasBread();
        }

        if (depositDoughButton != null)
        {
            depositDoughButton.interactable = selectedShelf != null && dough > 0 && selectedShelf.HasRoom();
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
        if (selectedShelf == null)
        {
            Debug.Log("No shelf selected.");
            return;
        }

        if (selectedShelf.TakeBread())
        {
            AddBread(1);
        }
        else
        {
            Debug.Log("Shelf is empty!");
        }
    }

    void DepositDoughToSelectedShelf()
    {
        if (selectedShelf == null)
        {
            Debug.Log("No shelf selected.");
            return;
        }

        if (dough <= 0)
        {
            Debug.Log("Not enough dough!");
            return;
        }

        if (!selectedShelf.HasRoom())
        {
            Debug.Log(selectedShelf.gameObject.name + " is already full.");
            return;
        }

        if (RemoveDough(1))
        {
            StartCoroutine(DelayedPart(selectedShelf, 3f));

            IEnumerator DelayedPart(ovenBreadAmount shelf, float time = 3f)
            {
                yield return new WaitForSeconds(time);
                if (shelf != null)
                {
                    shelf.AddBread(1);
                }
                Debug.Log("Baked bread at " + selectedShelf.gameObject.name);
            }
            
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

    public void SetSelectedShelf(ovenBreadAmount shelf)
    {
        selectedShelf = shelf;
    }

    public void ClearSelectedShelf(ovenBreadAmount shelf)
    {
        if (selectedShelf == shelf)
        {
            selectedShelf = null;
        }
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
