public class HealthSystemPlayer
{
    private int health;
    private int maxHealth;
    
    public HealthSystemPlayer(int maxHealth)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public int getHealth()
    {
        return health;
    }

    public float getHealthPercent()
    {
        return (float)health / maxHealth;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0) health = 0;
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)  health = maxHealth;
    }
}
