using UnityEngine.Events;
using UnityEngine;

public class OnTriggerEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent<float, float, float, float> Shake;
    [SerializeField] private float magnitude;
    [SerializeField] private float roughness;
    [SerializeField] private float fadeInTime;
    [SerializeField] private float fadeOutTime = 1f;

    [SerializeField] private UnityEvent<int> DealDamage;
    [SerializeField] private int damage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shake?.Invoke(magnitude, roughness, fadeInTime, fadeOutTime);
        DealDamage?.Invoke(damage);
    }
}