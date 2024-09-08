using UnityEngine;
using System.Collections;

public class SmoothHealthSliderBar : HealthSliderBar
{
    [SerializeField] private float _fillingSpeed;

    private Coroutine _coroutine;

    protected override void UpdateHealth(float health, float maxHealth)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        if (health == 0)
        {
            _slider.fillRect.gameObject.SetActive(false);
        }
        else
        {
            _slider.fillRect.gameObject.SetActive(true);
            _coroutine = StartCoroutine(SmoothFill(health, maxHealth));
        }
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator SmoothFill(float health, float maxHealth)
    {
        float value = health / maxHealth;

        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _fillingSpeed * Time.deltaTime);

            yield return null;
        }
    }
}