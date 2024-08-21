using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Mover _mover;
    [SerializeField] private Animator _animator;
    [SerializeField] private Health _health;
    [SerializeField] private float _damage = 25f;

    public Health Health => _health;

    private void Update()
    {
        CheckDeath();
    }

    private void FixedUpdate()
    {
        _mover.Move(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
            _mover.Jump();

        Flip();

        _animator.SetFloat("Speed", Mathf.Abs(_inputReader.Direction));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.TryGetComponent(out Enemy enemy)))
        Attack(enemy);
    }

    public bool IsAlive()
    {
        return _health.CurrentHealth > 0;
    }

    private void Flip()
    {
        float scaleX = 4;
        float scaleY = 4;

        if (_inputReader.Direction > 0)
            transform.localScale = new Vector2(scaleX, scaleY);
        else if (_inputReader.Direction < 0)
        transform.localScale = new Vector2(-scaleX, scaleY);
    }

    private void Attack(Enemy enemy)
    {
        if (enemy.Health != null)
            enemy.Health.TakeDamage(_damage);
        
    }

    private void CheckDeath()
    {
        if (IsAlive() == false)
           Destroy(gameObject);
    }
}