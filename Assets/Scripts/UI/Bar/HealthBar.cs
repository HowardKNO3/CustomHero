using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Bar
{
    public TextMeshProUGUI healthText;

    public override void UpdateBar(Character character)
    {
        double healthPercentage = character.Health / character.MaxHealth;
        slider.value = Mathf.Clamp01((float)healthPercentage);
        healthText.text = (int)character.Health + " / " + (int)character.MaxHealth;
    }
}
