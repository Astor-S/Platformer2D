using UnityEngine;

public class Fliper : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private Quaternion _rightRotation = Quaternion.Euler(0, 180, 0);
    private Quaternion _leftRotation = Quaternion.identity;

    public void Flip(Vector2 target)
    {
        if (_transform.position.x < target.x)
            _transform.rotation = _rightRotation;
        else
            _transform.rotation = _leftRotation;
    }

    public void Flip(float direction)
    {
        if (direction >= 0)
            _transform.rotation = _leftRotation;
        else if (direction < 0)
            _transform.rotation = _rightRotation;
    }
}