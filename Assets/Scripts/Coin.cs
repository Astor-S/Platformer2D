using UnityEngine;

public class Coin : Item
{
    [SerializeField] private int _rotationSpeedY = 100;
    private int _rotationSpeedX = 0;
    private int _rotationSpeedZ = 0;

    private int _coinValue = 1;
    
    private void Update()
    {
        transform.Rotate(_rotationSpeedX, _rotationSpeedY * Time.deltaTime, _rotationSpeedZ);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.TryGetComponent(out Player _)))
        {
            FindObjectOfType<Wallet>().AddCoins(_coinValue);
            Destroy(gameObject);
        }
    }
}