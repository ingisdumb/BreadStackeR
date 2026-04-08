using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 30.0f;

    private Rigidbody2D rb2d;
    private Vector2 velocity;

    private float xInput;
    private float yInput;

    public Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       xInput = Input.GetAxisRaw("Horizontal");
       yInput = Input.GetAxisRaw("Vertical");

       

        rb2d.velocity = new Vector2(xInput * speed, yInput * speed);
    }
}
