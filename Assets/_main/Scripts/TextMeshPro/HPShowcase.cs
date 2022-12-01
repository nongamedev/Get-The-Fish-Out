using UnityEngine;
using TMPro;

public class HPShowcase : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;
    [SerializeField] PlayerHealth playerHealth;
    private void Update()
    {
        tmp.text = "HP: " + playerHealth.currentHealth.ToString() + "/" + playerHealth.maxHealth.ToString();
    }
}
