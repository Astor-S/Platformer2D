using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VampirismDetected : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;
    
    private List<Enemy> _enemyDetected = new List<Enemy>();
    private CircleCollider2D _triggerCollider;

    public IReadOnlyList<Enemy> EnemyDetected => _enemyDetected.ToList();

    private void Awake()
    {
        _triggerCollider = GetComponent<CircleCollider2D>();
        _triggerCollider.isTrigger = true;
        _triggerCollider.radius = _vampirism.RadiusDrain;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy) && _enemyDetected.Contains(enemy) == false)
        {
            _enemyDetected.Add(enemy);
            enemy.Died += Lost;
        }    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
            Lost(enemy);
    }

    private void Lost(Enemy enemy)
    {
        enemy.Died -= Lost;
        _enemyDetected.Remove(enemy);
    }
}