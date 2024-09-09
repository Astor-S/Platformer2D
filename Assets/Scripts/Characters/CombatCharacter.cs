using System.Collections;
using UnityEngine;

public abstract class CombatCharacter : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Attacker _attacker;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;
    private float _delay = 2f;
    private bool _isCooldown = false;

    protected virtual void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CombatCharacter other))
        {
            if (_isCooldown == false)
            {
                _coroutine = StartCoroutine(AttackCooldown(other));
            }
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CombatCharacter _))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _isCooldown = false;
            }
        }
    }

    private protected virtual void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    private IEnumerator AttackCooldown(CombatCharacter target)
    {
        _isCooldown = true;

        while (_isCooldown)
        {
            target.TakeDamage(_attacker.Attack());

            yield return _wait;
        }
    }
}