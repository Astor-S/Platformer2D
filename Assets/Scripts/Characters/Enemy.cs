using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour 
{
    [SerializeField] private Health _health;
    [SerializeField] private Attacker _attacker;
    private EnemyMover _enemyMover;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;
    private float _delay = 2f;
    private bool _isCooldown = false;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        _enemyMover.Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.TryGetComponent(out Player player)))
            
            if (_isCooldown == false)
            {
                _coroutine = StartCoroutine(AttackCooldown());
                _attacker.Attack(player.TakeDamage());
            }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.gameObject.TryGetComponent(out Player player)))
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