using UnityEngine;

public class Picker : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private AudioClip _coinPickupSound;
    [SerializeField] private AudioClip _aidKitPickupSound;

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