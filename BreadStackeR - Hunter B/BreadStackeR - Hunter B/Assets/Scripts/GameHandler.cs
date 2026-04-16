using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public HealthBar healthBar;

    private HealthSystemPlayer healthSystem;

    public void damagePlayer(int damage)
    {
        healthSystem.Damage(damage);
    }

    void Start()
    {
        // Create and store the health system
        healthSystem = new HealthSystemPlayer(100);

        // Connect it to the UI
        healthBar.Setup(healthSystem);

        Debug.Log("Health: " + healthSystem.getHealth());
    }

    void Update()
    {
        // TEST INPUT (so you can see the slider move)

        if (Input.GetKeyDown(KeyCode.Q))
        {
            healthSystem.Damage(10);
            Debug.Log("Damage → " + healthSystem.getHealth());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            healthSystem.Heal(10);
            Debug.Log("Heal → " + healthSystem.getHealth());
        }
        if (healthSystem.getHealth() <= 0)
        {
            killPlayer();
        }
    }

    void killPlayer()
    {
        SceneManager.LoadScene("DeathScene");
    }
    
}