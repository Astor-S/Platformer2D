using UnityEngine;

[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Health))]
public class Picker : MonoBehaviour
{
    private Wallet _wallet;
    private Health _playerHealth;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _playerHealth = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
                _wallet.AddCoins(coin.CoinValue);
                Destroy(coin.gameObject);
        }

        if (other.gameObject.TryGetComponent(out AidKit aidKit))
        {
                _playerHealth.Heal(aidKit.HealthPoints);
                Destroy(aidKit.gameObject);
        }
    }
}