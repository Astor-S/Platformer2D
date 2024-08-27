using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<int> _availableIndexes;

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
        int minCount = 1;
        int minRange = 0;
        int maxRange = 2;

        int kitsToSpawn = Random.Range(minCount, _availableIndexes.Count);

        for (int i = 0; i < kitsToSpawn; i++)
        {
            int randomIndex = Random.Range(minRange, maxRange);

            int spawnPointIndex = _availableIndexes[randomIndex];

            Instantiate(_spawnPoints[spawnPointIndex].ItemPrefab, _spawnPoints[spawnPointIndex].Position.position, Quaternion.identity);

            _availableIndexes.RemoveAt(randomIndex);
        }
    }
}