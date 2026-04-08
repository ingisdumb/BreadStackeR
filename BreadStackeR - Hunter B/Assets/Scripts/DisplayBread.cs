using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayBread : MonoBehaviour
{
    public TMP_Text breadText;
    public TMP_Text moniesText;

    public TMP_Text doughText;

    public PlayerInventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        breadText.text = "Bread: " + playerInventory.bread.ToString();
        moniesText.text = "Monies: " + playerInventory.money.ToString();
        doughText.text = "Dough: " + playerInventory.dough.ToString();
    }
}
