using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<SpawnPoint> _spawnPointsAidKit;

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

        int kitsToSpawn = Random.Range(minCount, _spawnPointsAidKit.Count);

        for (int i = 0; i < kitsToSpawn; i++)
        {
            int randomPoint = Random.Range(minRange, maxRange);

            SpawnPoint spawnPoint = _spawnPointsAidKit[randomPoint];

            Instantiate(spawnPoint.ItemPrefab, spawnPoint.Position.position, Quaternion.identity);

            _spawnPointsAidKit.RemoveAt(randomPoint);
        }
    }
}