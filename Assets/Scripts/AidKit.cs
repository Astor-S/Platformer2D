using UnityEngine;

public class AidKit : Item
{
    [SerializeField] private float _healthPoints;

    private Health _health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.TryGetComponent(out Player _)))
        {
            if (_health == null)
            {
                _health = other.gameObject.GetComponent<Health>();
            }

            _health.Heal(_healthPoints);
            Destroy(gameObject);
        }
    }
}