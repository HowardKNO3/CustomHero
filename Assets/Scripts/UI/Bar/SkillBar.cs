using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SkillBar : Bar {
    public int skillIndex;
    Character character;
    public override void UpdateBar(Character character)
    {
        this.character = character;
        double skillPercentage = character.SkillFills[skillIndex];
        slider.value = Mathf.Clamp01((float)skillPercentage);
    }
    
    public override string GetTooltip() {
        Skill skill = character.Skills[skillIndex];
        return skill.skillName + "\n" + skill.description;
    }
}
