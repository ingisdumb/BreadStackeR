using UnityEngine;

public class BreadGet : MonoBehaviour
{
    public static ovenBreadAmount currentTarget; // Currently selected bread source
    public int decreaseAmount = 1;               // Amount to remove per click

    // Called by UI button
    public void OnButtonClick()
    {
        if (currentTarget != null)
        {
            currentTarget.RemoveBread(decreaseAmount);
        }
        else
        {
            Debug.Log("No object selected!");
        }
    }
}