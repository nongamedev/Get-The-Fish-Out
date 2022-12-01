using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnBulletHellsInInterval : MonoBehaviour
{
    [SerializeField] BulletHellSpawner[] bulletHellSpawners;

    [SerializeField] float timer = 2f;

    private int i = 0;

    private WaitForSeconds waitForTimer;

    void Start()
    {
        waitForTimer = new WaitForSeconds(timer);

        StartCoroutine(ActivateOnTimer());
    }

    //void Update() => bulletHellSpawners.Except(new GameObject[] { gameObject }).ToList().ForEach(g => g.SetActive(activateAll));

    private IEnumerator ActivateOnTimer()
    {
        while (true)
        {

            yield return waitForTimer;

            //bulletHellSpawners[i].gameObject.SetActive(true);

            //bulletHellSpawners[i].GenerateBulletHell();

            //const int V = 1;

            //i++;

            //if (i >= bulletHellSpawners.Length)
            //{
            //    i = 0;
            //}

            //bulletHellSpawners[i + V].gameObject.SetActive(false);

        }
    }
}
