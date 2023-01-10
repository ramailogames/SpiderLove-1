using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] platformsList;
    public Transform spawnPos;
    bool hasSpawned = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player"))
        {
            if (hasSpawned)
            {
                return;
            }

            hasSpawned = true;

            int index = Random.Range(0, platformsList.Length);

            Instantiate(platformsList[index], spawnPos.position, Quaternion.identity);
        }
    }
}
