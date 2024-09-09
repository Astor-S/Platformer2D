using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage;

    public float Attack()
    {     
            return _damage;
    }
}