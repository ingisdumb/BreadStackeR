using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Camera cam;
    public float smooth = 10f;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    void Start()
{
    GameObject[] borders = GameObject.FindGameObjectsWithTag("LevelBounds");

    minX = float.MaxValue;
    minY = float.MaxValue;
    maxX = float.MinValue;
    maxY = float.MinValue;

    foreach (GameObject border in borders)
    {
        Bounds b = border.GetComponent<Renderer>().bounds;
        if (b.min.x < minX) minX = b.min.x;
        if (b.min.y < minY) minY = b.min.y;
        if (b.max.x > maxX) maxX = b.max.x;
        if (b.max.y > maxY) maxY = b.max.y;
    }
}

    void LateUpdate()
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        Vector3 target = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, smooth * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX + camWidth, maxX - camWidth);
        pos.y = Mathf.Clamp(pos.y, minY + camHeight, maxY - camHeight);
        transform.position = pos;
    }
}