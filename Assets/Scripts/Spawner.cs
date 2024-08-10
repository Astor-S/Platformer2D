using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            Instantiate(spawnPoint.CoinPrefab, spawnPoint.Position.position, Quaternion.identity);
        }
    }
}