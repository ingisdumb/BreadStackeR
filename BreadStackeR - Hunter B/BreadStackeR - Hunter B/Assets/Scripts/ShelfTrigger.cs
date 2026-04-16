using UnityEngine;

public class ShelfTrigger : MonoBehaviour
{
    // UI references assigned in the Inspector
    public GameObject canvasUI;      // Default interaction UI
    public GameObject canvasBuy;     // Buy station UI
    public GameObject canvasSell;    // Sell station UI
    public GameObject alwaysOnUI;    // UI always visible unless interacting

    // Called when another collider enters this trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only respond if the player enters
        if (other.CompareTag("Player"))
        {
            Debug.Log("This object's tag: " + gameObject.tag);
            // Check if this object is tagged as a Buy Station
            if (CompareTag("Buy Station"))
            {
                if (canvasBuy != null)
                {
                    canvasBuy.SetActive(true);

                    // Hide always-on UI
                    if (alwaysOnUI != null)
                    {
                        alwaysOnUI.SetActive(false);
                    }
                }
                Debug.Log("Object tag is: [" + gameObject.tag + "]");
            }
            // Check if this object is tagged as a Sell Station
            else if (gameObject.CompareTag("Sell Station")) 
            {
                Debug.Log("SELL STATION BLOCK EXECUTING");
                if (canvasSell.name == "SellCanvas")
                {
                    Debug.Log("canvasSell is assigned");
                    canvasSell.SetActive(true);

                    // Hide always-on UI
                    if (alwaysOnUI != null)
                    {
                        alwaysOnUI.SetActive(false);
                    }
                }
            }
            // Default interaction UI
            else
            {
                Debug.Log("canvasSell is NULL - not assigned in Inspector!");
                Debug.Log(canvasSell);
                if (canvasUI != null)
                {
                    canvasUI.SetActive(true);

                    // Hide always-on UI
                    if (alwaysOnUI != null)
                    {
                        alwaysOnUI.SetActive(false);
                    }
                }
            }
        }
    }

    // Called when the player exits the trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable all contextual UI
            if (canvasUI != null) canvasUI.SetActive(false);
            if (canvasBuy != null) canvasBuy.SetActive(false);
            if (canvasSell != null) canvasSell.SetActive(false);

            // Re-enable always-on UI
            if (alwaysOnUI != null) alwaysOnUI.SetActive(true);
        }
    }
}
