using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smooth = 10f;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;



    void LateUpdate()
    {
        Vector3 target = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, smooth * Time.deltaTime);
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}