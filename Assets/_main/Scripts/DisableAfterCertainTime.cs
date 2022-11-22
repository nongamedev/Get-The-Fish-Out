using UnityEngine;

public class DisableAfterCertainTime : MonoBehaviour
{
    [SerializeField] float timer = 10f;
    float elapsed;

    private void OnEnable()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= timer)
        {
            elapsed = 0f;

            gameObject.SetActive(false);
        }
    }
}

