using UnityEngine;

public class Coin : Item
{
    [SerializeField] private int _rotationSpeedY = 100;
    private int _rotationSpeedX = 0;
    private int _rotationSpeedZ = 0;
    private int _coinValue = 1;

    public int CoinValue => _coinValue;

    private void Update()
    {
        transform.Rotate(_rotationSpeedX, _rotationSpeedY * Time.deltaTime, _rotationSpeedZ);
    }
}