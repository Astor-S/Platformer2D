using UnityEngine;

[RequireComponent(typeof(DetectionPlayer))]
[RequireComponent(typeof(Patrolling))]

public class Enemy : MonoBehaviour 
{
    [SerializeField] private Health _health;
    [SerializeField] private float _damage = 20f;
    private DetectionPlayer _detectionPlayer;
    private Patrolling _patrolling;

    public Health Health => _health;

    private void Start()
    {
        _detectionPlayer = GetComponent<DetectionPlayer>();
        _patrolling = GetComponent<Patrolling>();
    }

    private void Update()
    {
        CheckDeath();

        if (_detectionPlayer.IsPlayerDetected)
        {
            _patrolling.StopPatrol();
            transform.position = Vector2.MoveTowards(transform.position, _detectionPlayer.PlayerTransform.position, _patrolling.Speed * Time.deltaTime);
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

    public bool IsAlive()
    {
        return _health.CurrentHealth > 0;
    }

    private void Attack(Player player)
    {
        if (player.Health != null)
        player.Health.TakeDamage(_damage);
    }

    private void CheckDeath()
    {
        if (IsAlive() == false)
        Destroy(gameObject);
    }
}