using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage;

    public float Attack(Health targetHealth)
    {
            targetHealth.TakeDamage(_damage);
        
            return _damage;
    }
}