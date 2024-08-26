using UnityEngine;

public class Player : MonoBehaviour
{
    public readonly int Speed = Animator.StringToHash(nameof(Speed));

    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Mover _mover;
    [SerializeField] private Animator _animator;
    [SerializeField] private Health _health;
    [SerializeField] private float _damage = 25f;

    public Health Health => _health;
    public bool IsAlive => _health.CurrentHealth > 0;

    private void Update()
    {
        ApplyDeath();
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
            Attack(enemy);
    }

    private void Attack(Enemy enemy)
    {
        if (enemy.Health != null)
            enemy.Health.TakeDamage(_damage);    
    }

    private void ApplyDeath()
    {
        if (IsAlive == false)
           Destroy(gameObject);
    }
}