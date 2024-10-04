using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VampirismView : MonoBehaviour
{
    private const int RadiusToDiameter = 2;

    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private Transform _vampirizeArea;
    [SerializeField] private Slider _cooldownSlider;
    [SerializeField] private float _delay = 0.5f;

    private void Awake()
    {
        _vampirizeArea.localScale = Vector3.one * _vampirism.RadiusDrain * RadiusToDiameter;
        _vampirizeArea.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _vampirism.VampirizeStarted += ActivateView;
        _vampirism.VampirizeFinished += DisactivateView;
    }

    private void OnDisable()
    {
        _vampirism.VampirizeStarted -= ActivateView;
        _vampirism.VampirizeFinished -= DisactivateView;
    }

    private void ActivateView()
    {
        _vampirizeArea.gameObject.SetActive(true);
        StartCoroutine(UpdateCooldownBar());
    }

    private void DisactivateView()
    {
        _vampirizeArea.gameObject.SetActive(false);
        StartCoroutine(FillCooldownSlider());
    }

    private IEnumerator UpdateCooldownBar()
    {
        float elapsedTime = 0f;

        _cooldownSlider.value = 1f;

        while (elapsedTime < _vampirism.DurationTime)
        {
            float remainingTime = _vampirism.DurationTime - elapsedTime;

            _cooldownSlider.value = remainingTime / _vampirism.DurationTime;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        _cooldownSlider.value = 0f;
        
        if (_cooldownSlider.value == 0f)
            _cooldownSlider.fillRect.gameObject.SetActive(false);
    }

    private IEnumerator FillCooldownSlider()
    {
        yield return new WaitForSeconds(_delay);

        _cooldownSlider.fillRect.gameObject.SetActive(true);

        float elapsedTime = 0f;

        while (elapsedTime < _vampirism.Cooldown)
        {
            _cooldownSlider.value = elapsedTime / _vampirism.Cooldown;

            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}