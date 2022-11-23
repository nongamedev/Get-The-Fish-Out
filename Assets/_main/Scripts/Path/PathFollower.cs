using PathCreation;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] PathCreator pathCreator;
    [SerializeField] float speed = 5f;
    float distanceTravelled;

    private void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
    }
}
