using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillPanel : MonoBehaviour, ITippedObject
{
    public int skillIndex;
    Skill skill;
    Character character;
    public TextMeshProUGUI skillName;
    public void UpdatePanel(Character character) {
        this.character = character;
        skill = SkillManager.Instance.GetSkillById(character.characterData.skillIds[skillIndex]);
        skillName.text = skill.skillName;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.Instance.ShowTip(GetTooltip());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.Instance.HideTip();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        TooltipManager.Instance.UpdatePosition(Input.mousePosition);
    }

    public string GetTooltip() {
        Skill skill = SkillManager.Instance.GetSkillById(character.characterData.skillIds[skillIndex]);
        return skill.skillName + "\n" + skill.description;
    }
    
}
