using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillPanel : TooltipBehaviour
{
    public int skillIndex;
    Skill skill;
    Character character;
    public TextMeshProUGUI skillName;
    public void UpdatePanel(Character character) {
        this.character = character;
        skill = character.Skills[skillIndex];
        if (skill != null) skillName.text = skill.skillName;
    }

    public override string GetTooltip() {
        skill = character.Skills[skillIndex];
        return skill.skillName + "\n" + skill.description;
    }
    
}
