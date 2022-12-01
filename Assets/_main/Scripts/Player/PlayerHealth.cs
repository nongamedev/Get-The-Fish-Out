using UnityEngine;
[CreateAssetMenu(fileName = "PlayerHealth", menuName = "Player/Health")]
public class PlayerHealth : ScriptableObject
{
    public int maxHealth = 5;
    public int currentHealth = 5;
    public int increaseAmountAfterDeath = 50;
    
}
