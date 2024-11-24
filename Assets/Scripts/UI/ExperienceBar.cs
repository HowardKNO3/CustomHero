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


    public override void UpdateBar(Character character)
    {
        CharacterData characterData = character.characterData;
        double experiencePercentage = characterData.attributeExperiences[attributeIndex] / BASE_UPGRADE_EXPERIENCE;
        
        slider.value = Mathf.Clamp01((float)experiencePercentage);
        experienceText.text = "Lv." + characterData.attributeLevels[attributeIndex] + "          " + 
            (int)characterData.attributeExperiences[attributeIndex] + "/" + BASE_UPGRADE_EXPERIENCE;
        double getAmount = character.getExperienceAmount[attributeIndex];
        getExperienceText.text = "+" + (int)getAmount;
    }
}
