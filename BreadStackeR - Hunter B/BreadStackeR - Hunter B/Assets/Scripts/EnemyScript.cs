using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int damageAmount = 5;
    [SerializeField] private AudioSource shieldBash;
    [SerializeField] private AudioClip shieldBashClip;

    private Rigidbody2D rb;
    private Transform target;
    private GameHandler gameHandler;
    private Vector2 moveDirection;
    private bool isHit = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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

    void Update()
    {
        if (target == null || gameHandler == null)
            return;

        Vector3 direction = (target.position - transform.position).normalized;
        moveDirection = direction;
    }

    void FixedUpdate()
    {
        if (target != null && !isHit)
        {
            rb.velocity = moveDirection * moveSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameHandler.damagePlayer(damageAmount);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Shield"))
        {
            isHit = true;
            GetComponent<Collider2D>().enabled = false;
            rb.velocity = Vector2.zero;
            
            if (shieldBashClip != null)
            {
                shieldBash.PlayOneShot(shieldBashClip);
                Destroy(gameObject, shieldBashClip.length);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}