using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] int damage = 1;

    private void Start()
    {
        player = GameObject.Find(PlayerData.name).GetComponent<Player>();
    }
    private void OnParticleCollision(GameObject other)
    {
        player.TakeDamage(damage);
    }
}
