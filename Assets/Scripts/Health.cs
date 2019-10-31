using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public  int maxHealth = 100;
    public event Action<float, float> OnHealthChanged = delegate { };
    public int currentHealth { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Math.Max(0, Math.Min(currentHealth, maxHealth));

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthChanged(currentHealth, maxHealth);

        Debug.Log(transform.name + " takes damage " + amount.ToString() + " now has health of " + currentHealth.ToString() + "/" + maxHealth.ToString());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public virtual void Die()
    {
        // Different players may die in different ways - this method is meant to be override
        Debug.Log(transform.name + " died");
    }
}
