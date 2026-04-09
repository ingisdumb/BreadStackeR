using UnityEngine;

[RequireComponent(typeof(ovenBreadAmount))]
public class SelectableBread : MonoBehaviour
{
    private ovenBreadAmount bread;

    void Awake()
    {
        bread = GetComponent<ovenBreadAmount>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BreadGet.currentTarget = bread;
            Debug.Log(gameObject.name + " selected");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && BreadGet.currentTarget == bread)
        {
            BreadGet.currentTarget = null;
            Debug.Log(gameObject.name + " deselected");
        }
    }
}