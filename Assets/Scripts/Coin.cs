using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _rotationSpeedY = 100;
    private int _rotationSpeedX = 0;
    private int _rotationSpeedZ = 0;

    private void Update()
    {
        transform.Rotate(_rotationSpeedX, _rotationSpeedY * Time.deltaTime, _rotationSpeedZ);
    }
}