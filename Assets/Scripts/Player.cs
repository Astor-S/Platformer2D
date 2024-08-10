using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Mover _mover;
    [SerializeField] private Animator _animator;
    
    private void FixedUpdate()
    {
        _mover.Move(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
        }

        Flip();

        _animator.SetFloat("Speed", Mathf.Abs(_inputReader.Direction));
    }

    private void Flip()
    {
        float scaleX = 4;
        float scaleY = 4;

        if (_inputReader.Direction > 0)
        {
            transform.localScale = new Vector2(scaleX, scaleY);
        }
        else if (_inputReader.Direction < 0)
        {
            transform.localScale = new Vector2(-scaleX, scaleY);
        }
    }
}