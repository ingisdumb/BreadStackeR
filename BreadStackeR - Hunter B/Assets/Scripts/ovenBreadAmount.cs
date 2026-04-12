using UnityEngine;

public class ovenBreadAmount : MonoBehaviour
{
    public int breadAmount; // Current bread stored in this object

    void Start()
    {
        // Assign random bread amount for testing
        breadAmount = Random.Range(1, 10);
        Debug.Log(gameObject.name + " bread: " + breadAmount);
    }

    // Remove bread but never go below zero
    public void RemoveBread(int amount)
    {
        breadAmount = Mathf.Max(0, breadAmount - amount);
        Debug.Log(gameObject.name + " bread left: " + breadAmount);
    }
}