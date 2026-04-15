using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    public Transform target;      // your player
    public Vector3 offset;        // how high above the player
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(target.position + offset);
        transform.position = screenPos;
    }
}