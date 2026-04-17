using UnityEngine;

public class FlashlightFollowMouse : MonoBehaviour
{
    public Camera cam;
    public Transform player;

    [SerializeField] private float angleOffset = -90f; // fix for sprite orientation

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
            angle += angleOffset;

            transform.position = player.position;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}