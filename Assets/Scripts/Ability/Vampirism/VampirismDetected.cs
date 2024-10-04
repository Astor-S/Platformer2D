using System.Collections.Generic;
using UnityEngine;

public class VampirismDetected : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private LayerMask _enemyLayerMask;
    
    private List<Enemy> _enemyDetected = new List<Enemy>();

    public List<Enemy> EnemyDetected => _enemyDetected;

    private void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _vampirism.RadiusDrain, _enemyLayerMask);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.TryGetComponent(out Enemy enemy))
            {
                if (_enemyDetected.Contains(enemy) == false)
                {
                    _enemyDetected.Add(enemy);
                }
            }

            for (int i = _enemyDetected.Count - 1; i >= 0; i--)
            {
                if (Vector2.Distance(transform.position, _enemyDetected[i].transform.position) > _vampirism.RadiusDrain)
                {
                    _enemyDetected.RemoveAt(i);
                }
            }
        }
    }
}