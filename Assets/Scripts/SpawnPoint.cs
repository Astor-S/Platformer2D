using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] Transform _position;
    [SerializeField] private int _amount;

    public Coin CoinPrefab => _coinPrefab;
    public Transform Position => _position;
}