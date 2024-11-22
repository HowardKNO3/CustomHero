using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI healthText;

    public void UpdateHealthBar(Character character)
    {
        float healthPercentage = character.Health / character.characterData.maxHealth;
        healthSlider.value = Mathf.Clamp01(healthPercentage);
        healthText.text = (int)character.Health + " / " + (int)character.characterData.maxHealth;
    }
}
