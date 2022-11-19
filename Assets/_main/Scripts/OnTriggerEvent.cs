using UnityEngine;
using UnityEngine.Events;
public class OnTriggerEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onTriggerEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEvent?.Invoke();
    }
}
