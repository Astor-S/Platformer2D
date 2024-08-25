using UnityEngine;

[RequireComponent(typeof(PlayerDetector))]
[RequireComponent(typeof(Patroller))]

public class Enemy : MonoBehaviour 
{
    [SerializeField] private Health _health;
    [SerializeField] private float _damage = 20f;
    private PlayerDetector _playerDetection;
    private Patroller _patrolling;

    public Health Health => _health;
    public bool IsAlive => _health.CurrentHealth > 0;

    private void Start()
    {
        _playerDetection = GetComponent<PlayerDetector>();
        _patrolling = GetComponent<Patroller>();
    }

    private void Update()
    {
        ApplyDeath();

        if (_playerDetection.IsPlayerDetected)
        {
            _patrolling.StopPatrol();
            transform.position = Vector2.MoveTowards(transform.position, _playerDetection.PlayerTransform.position, _patrolling.Speed * Time.deltaTime);
        }
        else
        {
            _patrolling.ResumePatrol();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.TryGetComponent(out Player player)))
            Attack(player);
    }

    private void Attack(Player player)
    {
        if (player.Health != null)
            player.Health.TakeDamage(_damage);
    }

    private void ApplyDeath()
    {
        if (IsAlive == false)
            Destroy(gameObject);
    }
}