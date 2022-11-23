using UnityEngine;

public class MultiPoolDeactivateAfterCertainTime : MonoBehaviour
{
    [SerializeField] float timer = 10f;
    float elapsed;

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= timer)
        {
            elapsed = 0f;

            MultiPool.Instance.Deactivate(gameObject);
        }
    }
}

