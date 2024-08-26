using UnityEngine;

[RequireComponent(typeof(EnemyMover))]

public class Enemy : MonoBehaviour 
{
    [SerializeField] private Health _health;
    [SerializeField] private float _damage = 20f;
    private EnemyMover _enemyMover;

    public Health Health => _health;
    public bool IsAlive => _health.CurrentHealth > 0;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        ApplyDeath();

        _enemyMover.Move();
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