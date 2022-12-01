using UnityEngine;

public class OnParticleTriggerEvent : MonoBehaviour
{
    [SerializeField] private Player player;

    private void OnParticleTrigger()
    {
        player.TakeDamage(1);
    }
}
