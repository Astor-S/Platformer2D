using UnityEngine;
using UnityEngine.UI;

public class HealthSliderBar : HealthBar
{
    [SerializeField] private protected Slider _slider;
    [SerializeField] private RectTransform _targetCanvas;
    [SerializeField] private Transform _followedObject;

    protected override void UpdateHealth(float health, float maxHealth)
    {
        if (health == 0)
        {
            _slider.fillRect.gameObject.SetActive(false);
        }
        else
        {
            _slider.value = health / maxHealth;
            _slider.fillRect.gameObject.SetActive(true);
        }
    }
}