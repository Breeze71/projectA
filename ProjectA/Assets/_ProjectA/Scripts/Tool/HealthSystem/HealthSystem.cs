using System;

public class HealthSystem
{
    public event EventHandler OnHealthChanged;

    private int currentHealth;
    private int maxHealth;

    public HealthSystem(int _maxHealth)
    {
        maxHealth = _maxHealth;
        currentHealth = maxHealth;
    }

    public int GetHealthAmount()
    {
        return currentHealth;
    }
    
    public float GetHealthPercent()
    {
        return (float)currentHealth / maxHealth;
    }

    public void TakeDamage(int _damageAmount)
    {
        currentHealth -= _damageAmount;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }

        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public void TakeHealing(int _healingAmount)
    {
        currentHealth += _healingAmount;

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }
}
