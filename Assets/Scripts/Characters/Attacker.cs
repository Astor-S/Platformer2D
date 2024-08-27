using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage;

    public void Attack(Health targetHealth)
    {
            targetHealth.TakeDamage(_damage);
    }
}