using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 2f;

    public int damageAmount = 5;

    private Rigidbody2D rb;
    private Transform target;

    private Vector2 moveDirection;
    
    public GameHandler gameHandler;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            target = playerObject.transform;
        }

        if (gameHandler == null)
        {
            gameHandler = FindObjectOfType<GameHandler>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null || gameHandler == null)
        {
            return;
        }

        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
            
            /* EXTRA: Set direction of enemy to player's direction
             float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
             rb.rotation = angle;
             */
            
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameHandler != null)
            {
                gameHandler.damagePlayer(damageAmount);
            }

            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }
}
