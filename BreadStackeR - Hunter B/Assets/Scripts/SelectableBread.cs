using UnityEngine;

// Ensures this object has an ovenBreadAmount component
[RequireComponent(typeof(ovenBreadAmount))]
public class SelectableBread : MonoBehaviour
{
    private ovenBreadAmount bread; // Reference to bread data

    void Awake()
    {
        // Cache the ovenBreadAmount component
        bread = GetComponent<ovenBreadAmount>();
    }

    // When player enters trigger, mark this bread as selected
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BreadGet.currentTarget = bread;
            Debug.Log(gameObject.name + " selected");
        }
    }

    // When player leaves, deselect if it's the current target
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && BreadGet.currentTarget == bread)
        {
            BreadGet.currentTarget = null;
            Debug.Log(gameObject.name + " deselected");
        }
    }
}