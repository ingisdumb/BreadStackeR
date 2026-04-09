using UnityEngine;

public class BreadGet : MonoBehaviour
{
    public static ovenBreadAmount currentTarget;
    public int decreaseAmount = 1;

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