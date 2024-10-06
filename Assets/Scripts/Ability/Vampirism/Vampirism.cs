using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Vampirism : MonoBehaviour
{
    [SerializeField] private VampirismDetected _detected;
    [SerializeField] private KeyCode _vampirismKey = KeyCode.V;
    [SerializeField] private float _healthDrain = 5f;
    [SerializeField] private float _cooldown = 4.5f;
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _radiusDrain = 3f;

    private Health _health;
    private Coroutine _coroutine;
    private Enemy _currentTarget;
    
    public float RadiusDrain => _radiusDrain;
    public float DurationTime => _duration;
    public float Cooldown => _cooldown;

    public event Action VampirizeStarted;
    public event Action VampirizeFinished;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_vampirismKey))
        {
            if (_coroutine == null)
            {
                Enemy nearestEnemy = GetNearestEnemy();

                if (nearestEnemy != null)
                {
                    VampirizeStarted?.Invoke();
                    _coroutine = StartCoroutine(VampirismAbility(nearestEnemy));
                }
            }
        }
    }

    private Enemy GetNearestEnemy()
    {
        Enemy nearestEnemy = null;

        float shortestDistance = float.MaxValue;

        foreach (Enemy enemy in _detected.EnemyDetected)
        {
            if (enemy == null)
                continue;

            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    private IEnumerator VampirismAbility(Enemy targetEnemy)
    {
        _currentTarget = targetEnemy;

        if (targetEnemy.Health == null)
            yield break;

        float elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            if (_currentTarget == null)
            {
                Enemy nearestEnemy = GetNearestEnemy();

                if (nearestEnemy != null)
                {
                    _currentTarget = nearestEnemy;

                    if (targetEnemy.Health == null) 
                        yield break;
                }
                else
                {
                    yield break;
                }
            }

            float drainAmount = _healthDrain * Time.deltaTime;

            _currentTarget.Health.TakeDamage(drainAmount);
            _health.TakeHeal(drainAmount);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        VampirizeFinished?.Invoke();
        _coroutine = null;
    }
}