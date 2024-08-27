using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;

    public event Action ValueChanged;

    public float Value { get; private set; }
    public float MaxValue => _maxValue;
    public float CurrentHealth => Value;
    public bool IsAlive => CurrentHealth > 0;

    private void Start()
    {
        Value = MaxValue;
    }

    public void Heal(float value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        UpdateValue(Value + value);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        UpdateValue(Value - damage);
        
        if (Value <= 0)
            ApplyDeath();
    }


    private void UpdateValue(float value)
    {
        Value = Mathf.Clamp(value, 0, _maxValue);
        ValueChanged?.Invoke();
    }

    private void ApplyDeath()
    {
        if (IsAlive == false)
            Destroy(gameObject);
    }
}