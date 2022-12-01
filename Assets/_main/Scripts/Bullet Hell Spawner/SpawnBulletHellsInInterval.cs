using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnBulletHellsInInterval : MonoBehaviour
{
    [SerializeField] BulletHellSpawner[] bulletHellSpawners;

    [SerializeField] float timer = 2f;

    private WaitForSeconds waitForTimer;

    private int currentIndex;

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


            for (int i = 0; i < bulletHellSpawners.Length; i++)
            {
                if (i != currentIndex)
                {
                bulletHellSpawners[i].StopBulletHell();
                }

                if (i == currentIndex)
                {
                    bulletHellSpawners[i].ResumeBulletHell();
                }

            }

            currentIndex++;

            if (currentIndex >= bulletHellSpawners.Length)
            {
                currentIndex = 0;
            }
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
