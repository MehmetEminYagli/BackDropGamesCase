using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneratorChest : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public GameObject chestPrefab; 
    void Start()
    {
        if (spawnPoints.Count > 0 && chestPrefab != null)
        {
            SpawnRandomChest();
        }
        else
        {
            Debug.LogError("spawnpoints listesi bos");
        }
    }
    void SpawnRandomChest()
    {
        int randomChestCount = Random.Range(1, spawnPoints.Count);
        for (int i =0; i< randomChestCount; i++)
        {
            int randomIndex = Random.Range(1, spawnPoints.Count);
            Instantiate(chestPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        }
    }
}
