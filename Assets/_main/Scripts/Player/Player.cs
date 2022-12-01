using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealthSO;
    private bool isInvincible;
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            playerHealthSO.currentHealth -= damage;

            if (playerHealthSO.currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        playerHealthSO.maxHealth += playerHealthSO.increaseAmountAfterDeath;
        playerHealthSO.currentHealth = playerHealthSO.maxHealth;
    }
}
