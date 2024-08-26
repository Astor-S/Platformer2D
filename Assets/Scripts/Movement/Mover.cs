using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speedX = 2f;
    [SerializeField] private float _jumpForce = 350f;
    [SerializeField] private Rigidbody2D _rigidbody;
    private Quaternion _rightRotation = Quaternion.identity;
    private Quaternion _leftRotation = Quaternion.Euler(0, 180, 0);

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(new Vector2(0, _jumpForce));
    }

    public void Move(float direction)
    {
        _rigidbody.velocity = new Vector2(_speedX * direction, _rigidbody.velocity.y);
    }

    public void Flip(float direction)
    {
        if (direction >= 0)
            transform.rotation = _rightRotation;
        else if (direction < 0)
            transform.rotation = _leftRotation;
    }
}