using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coins;

    private void Start()
    {
        _coins = 0;
    }

    public void AddCoins(int amount)
    {
        _coins += amount;
    }
}
