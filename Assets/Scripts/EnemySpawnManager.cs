using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject workerMalePrefab;
    public GameObject workerFemalePrefab;
    public GameObject kettlePrefab;
    public GameObject guardPrefab;
    public GameObject miniBossPrefab;
    public GameObject bossPrefab;

    public RectTransform[] spawnPoints;

    public int currentFloor = 1;

    private List<RectTransform> avaliblePoints;

    private void Start()
    {
        avaliblePoints = new List<RectTransform>(spawnPoints);
        SpawnEnemiesForFloor(currentFloor);
    }

    

    void SpawnEnemiesForFloor(int floor)
    {
        switch(floor)
        {
            case 1:
                if(Random.value < 0.5)
                {
                    Spawn(workerFemalePrefab, 1);
                }
                else
                {
                    Spawn(workerMalePrefab, 1);
                }
                break;

            case 2:
                if (Random.value < 0.5)
                {
                    Spawn(workerFemalePrefab, 1);
                }
                else
                {
                    Spawn(workerMalePrefab, 1);
                }

                if(Random.value < 0.6f)
                {
                    Spawn(kettlePrefab, 1);
                }
                if (Random.value < 0.2)
                {
                    if (Random.value < 0.5)
                    {
                        Spawn(workerFemalePrefab, 1);
                    }
                    else
                    {
                        Spawn(workerMalePrefab, 1);
                    }
                }
                break;

            case 3:
                Spawn(workerFemalePrefab, 1);
                Spawn(workerMalePrefab, 1);
                Spawn(guardPrefab, 1);

                break;

            case 4:
                //Spawn(miniBossPrefab, 1);

                if (Random.value < 0.2f)
                {
                    Spawn(guardPrefab, 1);
                    if (Random.value < 0.5)
                    {
                        Spawn(workerFemalePrefab, 1);
                    }
                    else
                    {
                        Spawn(workerMalePrefab, 1);
                    }
                }
                else
                {
                    Spawn(workerMalePrefab, 1);
                    Spawn(workerFemalePrefab, 1);
                }
                break;

            case 5:
                if (Random.value < 0.2f)
                {
                    Spawn(guardPrefab, 1);
                    Spawn(workerMalePrefab, 1);
                    Spawn(workerFemalePrefab, 1);
                }
                else
                {
                    Spawn(workerMalePrefab, 2);
                    Spawn(workerFemalePrefab, 2);
                }
                break;

            case 6:
                Spawn(kettlePrefab, 2);

                if (Random.value < 0.5f)
                    Spawn(guardPrefab, 1);

                if (Random.value < 0.1f)
                    //Spawn(miniBossPrefab, 1);
                    print("MiniBoss spawned");

                break;

            case 7:
                Spawn(guardPrefab, 3);
                break;

            case 8:
                Spawn(bossPrefab, 1);
                break;

        }
    }

    void Spawn(GameObject prefab, int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            if (avaliblePoints.Count == 0)
            {
                Debug.Log("No spawn points left");
                return;
            }

            //picks a random spawnpoint that has not already been selected
            int index = Random.Range(0, avaliblePoints.Count);
            RectTransform point = avaliblePoints[index];
            avaliblePoints.RemoveAt(index);

            GameObject enemy = Instantiate(prefab, point.position, Quaternion.identity, point.parent);

            // Matches the UI positioning
            RectTransform enemyRT = enemy.GetComponent<RectTransform>();
            enemyRT.anchoredPosition = point.anchoredPosition;
        }
    }
}
