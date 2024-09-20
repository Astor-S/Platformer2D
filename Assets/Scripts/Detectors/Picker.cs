using UnityEngine;

[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Health))]
public class Picker : MonoBehaviour
{
    [SerializeField] private AudioClip _coinPickupSound;
    [SerializeField] private AudioClip _aidKitPickupSound;
    
    private Wallet _wallet;
    private Health _playerHealth;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _playerHealth = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Item item))
        {
            if (item is Coin coin)
            {
                AudioSource.PlayClipAtPoint(_coinPickupSound, transform.position);
                _wallet.AddCoins(coin.Value);
            }
            else if (item is AidKit aidKit)
            {
                AudioSource.PlayClipAtPoint(_aidKitPickupSound, transform.position);
                _playerHealth.TakeHeal(aidKit.HealthPoints);
            }

            Destroy(item.gameObject);
        }
    }
}