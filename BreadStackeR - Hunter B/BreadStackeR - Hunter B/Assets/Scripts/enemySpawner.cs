using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    public float xThreshold;
    public float spawnInterval = 3f;
    public float currentTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null || enemyPrefab == null)
        {
            return;
        }

        if (player.position.x > xThreshold)
        {
            currentTimer -= Time.deltaTime;
            
            if (currentTimer <= 0)
            {
                GameObject spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                spawnedEnemy.SetActive(true);
                currentTimer = spawnInterval;
            }
        }
        else
        {
            currentTimer = spawnInterval;
        }
    }
}
