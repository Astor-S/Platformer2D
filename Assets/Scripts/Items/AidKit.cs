using UnityEngine;

public class AidKit : Item
{
    [SerializeField] private float _healthPoints;

    public float HealthPoints => _healthPoints;
}