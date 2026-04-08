using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfTrigger : MonoBehaviour
{
    public GameObject canvasUI; //assigned in inspector
    public GameObject canvasUI2; //assigned in inspector
    public GameObject canvasUI3; //assigned in inspector
    public GameObject alwaysOnUI; //assigned in inspector

    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        if (CompareTag("Buy Station"))
        {
            if (canvasUI2 != null)
                {
                    canvasUI2.SetActive(true);
                    if (alwaysOnUI != null)
                    {
                        alwaysOnUI.SetActive(false);
                    }
                }
                
        }
        else if (CompareTag("Sell Station"))
        {
            if (canvasUI3 != null)
                {
                    canvasUI3.SetActive(true);
                if (alwaysOnUI != null)
                    {
                        alwaysOnUI.SetActive(false);;
                    }
                }
                
        }
        else
        {
            if (canvasUI != null)
                {
                    canvasUI.SetActive(true);
                    if (alwaysOnUI != null)
                    {
                        alwaysOnUI.SetActive(false);
                    }
                }
                
        } //holy closing braces :sob emoji:
    }
}
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (canvasUI != null) canvasUI.SetActive(false);
            if (canvasUI2 != null) canvasUI2.SetActive(false);
            if (canvasUI3 != null) canvasUI3.SetActive(false);
            if (alwaysOnUI != null) alwaysOnUI.SetActive(true);
        }
    }
}    

