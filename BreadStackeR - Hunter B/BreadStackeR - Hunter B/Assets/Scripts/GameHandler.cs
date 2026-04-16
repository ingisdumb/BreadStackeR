using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public HealthBar healthBar;

    private HealthSystemPlayer healthSystem;

    public void damagePlayer(int damage)
    {
        healthSystem.Damage(damage);

        if (healthSystem.getHealth() <= 0)
        {
            killPlayer();
        }
    }

    void Start()
    {
        // Create and store the health system
        healthSystem = new HealthSystemPlayer(100);

        // Connect it to the UI
        healthBar.Setup(healthSystem);

        Debug.Log("Health: " + healthSystem.getHealth());
    }

    void killPlayer()
    {
        SceneManager.LoadScene("DeathScene");
    }
    
}
