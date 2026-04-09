using UnityEngine;

public class ovenBreadAmount : MonoBehaviour
{
    public int breadAmount;

    void Start()
    {
        // Random bread for testing
        breadAmount = Random.Range(1, 10);
        Debug.Log(gameObject.name + " bread: " + breadAmount);
    }

    public void RemoveBread(int amount)
    {
        breadAmount = Mathf.Max(0, breadAmount - amount);
        Debug.Log(gameObject.name + " bread left: " + breadAmount);
    }
}