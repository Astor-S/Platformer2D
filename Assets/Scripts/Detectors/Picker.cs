using UnityEngine;

[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Health))]

public class Picker : MonoBehaviour
{
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            if (_wallet != null)
            {
                _wallet.AddCoins(coin.CoinValue);
                Destroy(coin.gameObject);
            }
        }

        if (other.gameObject.TryGetComponent(out AidKit aidKit))
        {
            Health playerHealth = GetComponent<Health>();

            if (playerHealth != null)
            {
                playerHealth.Heal(aidKit.HealthPoints);
                Destroy(aidKit.gameObject);
            }
        }
    }
}