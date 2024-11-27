using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Constants;
public class ExperienceBar : Bar
{
    public int attributeIndex;
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI getExperienceText;
    Character character;


    public override void UpdateBar(Character character)
    {
        this.character = character;
        double expRequirement = character.AttributeExperienceRequirements[attributeIndex];
        double experiencePercentage = character.AttributeExperiences[attributeIndex] / expRequirement;
        
        slider.value = Mathf.Clamp01((float)experiencePercentage);
        experienceText.text = "Lv." + character.AttributeLevels[attributeIndex] + "          " + 
            (int)character.AttributeExperiences[attributeIndex] + "/" + (int)expRequirement;

        if (getExperienceText != null) {
            double getAmount = character.gainExperienceAmount[attributeIndex];
            getExperienceText.text = "+" + (int)getAmount;
        }
    }

    public override string GetTooltip() {
        return "還需要 " + (int)(character.AttributeExperienceRequirements[attributeIndex] - 
                character.AttributeExperiences[attributeIndex]) + " 經驗升至下一級";
    }
}
