using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
    public float speed = 30.0f; // Movement speed

    public GameObject shieldObject;

    private Rigidbody2D rb2d;

    private float xInput;
    private float yInput;

    void Start()
    {
        // Cache Rigidbody component
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get raw input (no smoothing)
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        // Apply movement
        rb2d.velocity = new Vector2(xInput * speed, yInput * speed);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            shieldObject.SetActive(true);
        }
        else shieldObject.SetActive(false);
    }
}
