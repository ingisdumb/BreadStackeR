using UnityEngine;

// Ensures this object has an ovenBreadAmount component
public class SelectableBread : MonoBehaviour
{
    private ovenBreadAmount bread; // Reference to bread data

    void Awake()
    {
        // Cache the ovenBreadAmount component
        bread = GetComponent<ovenBreadAmount>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            Debug.Log("SelectableBread ENTER ignored (not player): " + other.name);
            return;
        }

        Debug.Log("SelectableBread ENTER: " + other.name);

        PlayerInventory inventory = other.GetComponent<PlayerInventory>();
        if (inventory == null)
        {
            Debug.Log("SelectableBread ENTER failed: no PlayerInventory found on " + other.name);
            return;
        }

        // Check if THIS object is an oven
        OvenBaker oven = GetComponent<OvenBaker>();
        if (oven == null && gameObject.CompareTag("Oven"))
            oven = GetComponentInParent<OvenBaker>();

        Debug.Log("SelectableBread ENTER check oven on: " + gameObject.name + " result: " + (oven != null));

        if (oven != null)
        {
            inventory.SetSelectedOven(oven);
            Debug.Log(gameObject.name + " oven selected");
            return;
        }

        Debug.Log("SelectableBread ENTER: no oven detected, checking storage on " + gameObject.name);

        // Otherwise treat as storage shelf
        ovenBreadAmount storage = GetComponent<ovenBreadAmount>();
        if (storage == null)
            storage = GetComponentInParent<ovenBreadAmount>();

        if (storage != null)
        {
            Debug.Log("SelectableBread ENTER storage found: " + gameObject.name);
            inventory.SetSelectedStorage(storage);
            Debug.Log(gameObject.name + " storage selected");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            Debug.Log("SelectableBread EXIT ignored (not player): " + other.name);
            return;
        }

        Debug.Log("SelectableBread EXIT: " + other.name);

        PlayerInventory inventory = other.GetComponent<PlayerInventory>();
        if (inventory == null)
        {
            Debug.Log("SelectableBread EXIT failed: no PlayerInventory found on " + other.name);
            return;
        }

        Debug.Log("SelectableBread EXIT checking oven on: " + gameObject.name);

        // Clear oven selection if leaving oven
        OvenBaker oven = GetComponent<OvenBaker>();
        if (oven == null && gameObject.CompareTag("Oven"))
            oven = GetComponentInParent<OvenBaker>();

        if (oven != null)
        {
            Debug.Log("SelectableBread EXIT oven detected: " + gameObject.name);
            inventory.ClearSelectedOven(oven);
            Debug.Log(gameObject.name + " oven deselected");
            return;
        }

        // Clear storage selection if leaving shelf
        ovenBreadAmount storage = GetComponent<ovenBreadAmount>();
        if (storage == null)
            storage = GetComponentInParent<ovenBreadAmount>();

        if (storage != null)
        {
            Debug.Log("SelectableBread EXIT storage detected: " + gameObject.name);
            inventory.ClearSelectedStorage(storage);
            Debug.Log(gameObject.name + " storage deselected");
        }
    }
}
