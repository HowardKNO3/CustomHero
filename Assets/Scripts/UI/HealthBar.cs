using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public void UpdateHealthBar(Character character)
    {
        float healthPercentage = character.Health / character.characterData.maxHealth;
        healthSlider.value = Mathf.Clamp01(healthPercentage);
    }
}
