using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHealth", menuName = "Player/Health")]
public class PlayerHealth : ScriptableObject
{
    public int maxHealth = 5;
    public int currentHealth = 5;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();  
        }
    }

    private void Die()
    {
        currentHealth = maxHealth;
    }
}
