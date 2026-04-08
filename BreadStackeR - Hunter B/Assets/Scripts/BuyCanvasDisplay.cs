using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyCanvasDisplay : MonoBehaviour
{
    public TMP_Text moniesText;

    public PlayerInventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moniesText.text = "Monies: " + playerInventory.money.ToString();
    }
}
