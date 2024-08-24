using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private void Start()
    {
        SpawnCoins();
        SpawnAidKit();
    }

    private void SpawnCoins()
    {
        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            if (spawnPoint.ItemPrefab is Coin) 
                Instantiate(spawnPoint.ItemPrefab, spawnPoint.Position.position, Quaternion.identity);          
        }
    }

    private void SpawnAidKit()
    {
        List<int> availableIndexes = new List<int>(); 
        
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            if (_spawnPoints[i].ItemPrefab is AidKit)
                availableIndexes.Add(i);
        }

        int minCount = 1;
        int minRange = 0;
        int maxRange = 2;

        int kitsToSpawn = Random.Range(minCount, availableIndexes.Count);
        
        for (int i = 0; i < kitsToSpawn; i++)
        {
            int randomIndex = Random.Range(minRange, maxRange); 

            int spawnPointIndex = availableIndexes[randomIndex]; 

            Instantiate(_spawnPoints[spawnPointIndex].ItemPrefab, _spawnPoints[spawnPointIndex].Position.position, Quaternion.identity);

            availableIndexes.RemoveAt(randomIndex); 
        }
    }
}