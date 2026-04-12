using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 30.0f; // Movement speed

    private Rigidbody2D rb2d;
    private Vector2 velocity;

    private float xInput;
    private float yInput;

    public Animator animator; // Animator reference (currently unused)

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
    }
}