using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    void Start()
    {
        UpdateHealthBar(healthSlider.value);
    }

    public void UpdateHealthBar(float healthPercentage)
    {
        healthSlider.value = Mathf.Clamp01(healthPercentage);
    }
}
