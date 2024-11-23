using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Constants;
public class ExperienceBar : MonoBehaviour
{
    public int attributeIndex;
    public Slider experienceSlider;
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI getExperienceText;


    public void UpdateExperienceBar(Character character)
    {
        CharacterData characterData = character.characterData;
        double experiencePercentage = characterData.attributeExperiences[attributeIndex] / BASE_UPGRADE_EXPERIENCE;
        
        experienceSlider.value = Mathf.Clamp01((float)experiencePercentage);
        experienceText.text = "Lv." + characterData.attributeLevels[attributeIndex] + "          " + 
            (int)characterData.attributeExperiences[attributeIndex] + "/" + BASE_UPGRADE_EXPERIENCE;
        double getAmount = character.getExperienceAmount[attributeIndex];
        getExperienceText.text = "+" + (int)getAmount;
    }
}
