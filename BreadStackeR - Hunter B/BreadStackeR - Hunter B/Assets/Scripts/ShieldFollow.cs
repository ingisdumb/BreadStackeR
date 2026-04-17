using UnityEngine;

public class ShieldFollow : MonoBehaviour
{
    public Camera cam;
    public Transform player;

    void Update()
    {
        Vector3 mouseScreen = Input.mousePosition;
        // Raycast to world plane (stable, camera-independent feel)
        Ray ray = cam.ScreenPointToRay(mouseScreen);
        Plane plane = new Plane(Vector3.forward, Vector3.zero);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 mouseWorld = ray.GetPoint(distance);

            Vector2 dir = (mouseWorld - player.position);

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            float rad = angle * Mathf.Deg2Rad;

            float radius = 1.5f;

            transform.position = new Vector3(
                player.position.x + Mathf.Cos(rad) * radius, 
                player.position.y + Mathf.Sin(rad) * radius, 
                0f);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}