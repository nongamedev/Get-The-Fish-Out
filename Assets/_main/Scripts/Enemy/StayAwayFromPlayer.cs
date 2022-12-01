using UnityEngine;

public class StayAwayFromPlayer : MonoBehaviour
{
    [SerializeField] float yOffset = 20f;
    [SerializeField] Transform playerTransform;

    void Update()
    {
        transform.SetPositionAndRotation(new Vector3(transform.position.x, playerTransform.position.y + yOffset, transform.position.z), Quaternion.identity);
    }
}
