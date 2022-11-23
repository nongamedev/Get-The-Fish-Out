using UnityEngine;

public class MultiPoolRandomSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnpoints;
    [SerializeField] GameObject[] prefabs;
    [SerializeField] float timer = 3f;
    float elapsed;
    [SerializeField] Transform playerTransform;
    [SerializeField] float yOffsetToPlayer = 25f;

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= timer)
        {
            elapsed = 0f;

            int _randEnemyID = Random.Range(0, prefabs.Length);
            int _randSpawnpoint = Random.Range(0, spawnpoints.Length);

            MultiPool.Instance.Activate(_randEnemyID, new Vector3(spawnpoints[_randSpawnpoint].position.x, playerTransform.position.y + yOffsetToPlayer, spawnpoints[_randSpawnpoint].position.z), transform.rotation);
            //Instantiate(prefabs[_randEnemyID], new Vector3(spawnpoints[_randSpawnpoint].position.x, playerTransform.position.y + yOffsetToPlayer, spawnpoints[_randSpawnpoint].position.z), transform.rotation);
        }
    }

}
