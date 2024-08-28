using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : CombatCharacter 
{
    private EnemyMover _enemyMover;

    protected override void Awake()
    {
        base.Awake();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        _enemyMover.Move();
    }
}