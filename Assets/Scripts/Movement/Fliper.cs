using UnityEngine;

public class Fliper : MonoBehaviour
{
    private Quaternion _rightRotation = Quaternion.Euler(0, 180, 0);
    private Quaternion _leftRotation = Quaternion.identity;

    public void Flip(Vector2 target)
    {
        if (transform.position.x < target.x)
            transform.rotation = _rightRotation;
        else
            transform.rotation = _leftRotation;
    }

    public void Flip(float direction)
    {
        if (direction >= 0)
            transform.rotation = _leftRotation;
        else if (direction < 0)
            transform.rotation = _rightRotation;
    }
}