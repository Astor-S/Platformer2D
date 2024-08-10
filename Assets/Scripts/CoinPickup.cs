using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private int _coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.TryGetComponent(out Player _)))
        {
            FindObjectOfType<Wallet>().AddCoins(_coinValue);
            Destroy(gameObject);
        }
    }
}