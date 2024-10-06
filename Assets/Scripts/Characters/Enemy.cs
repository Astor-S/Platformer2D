using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyMover))]
public class Enemy : CombatCharacter 
{
    private EnemyMover _enemyMover;

    public event Action<Enemy> Died;

    public Health Health { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        _enemyMover = GetComponent<EnemyMover>();
        Health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        Health.Died += () => Died?.Invoke(this);
    }

    private void OnDisable()
    {
        Health.Died -= () => Died?.Invoke(this);
    }

    private void Update()
    {
        _enemyMover.Move();
    }
}