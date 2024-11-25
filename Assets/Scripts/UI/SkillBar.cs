using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SkillBar : Bar, ITippedObject {
    public int skillIndex;
    Character character;
    public override void UpdateBar(Character character)
    {
        this.character = character;
        double skillPercentage = character.SkillFills[skillIndex];
        slider.value = Mathf.Clamp01((float)skillPercentage);
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
