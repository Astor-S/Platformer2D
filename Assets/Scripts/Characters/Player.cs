using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public readonly int Speed = Animator.StringToHash(nameof(Speed));

    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Mover _mover;
    [SerializeField] private Animator _animator;
    [SerializeField] private Health _health;
    [SerializeField] private Attacker _attacker;
    
    private Coroutine _coroutine;
    private WaitForSeconds _wait;
    private float _delay = 2f;
    private bool _isCooldown = false;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void FixedUpdate()
    {
        _mover.Flip(_inputReader.Direction);
        _mover.Move(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
            _mover.Jump();

        _animator.SetFloat(Speed, Mathf.Abs(_inputReader.Direction));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.TryGetComponent(out Enemy enemy)))
            
            if (_isCooldown == false)
            {
                _coroutine = StartCoroutine(AttackCooldown());
                _attacker.Attack(enemy.TakeDamage());
            }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.gameObject.TryGetComponent(out Enemy enemy)))
        {
            StopCoroutine(_coroutine);
            _isCooldown = false;
        }
    }

    public Health TakeDamage()
    {
        return _health;
    }

    private IEnumerator AttackCooldown()
    {
        _isCooldown = true;
        yield return _wait;
        _isCooldown = false;
    }
}