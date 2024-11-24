using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SkillBar : Bar, ITippedObject, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public int skillIndex;

    // Method to update both the skill bar's fill amount and the slider's value
    public override void UpdateBar(Character character)
    {
        
        double skillPercentage = character.SkillFills[skillIndex];
        slider.value = Mathf.Clamp01((float)skillPercentage);
    }
    

    public void OnPointerEnter(PointerEventData eventData) {
        TooltipManager.Instance.ShowTip("");
    }

    public void OnPointerExit(PointerEventData eventData) {
        TooltipManager.Instance.HideTip();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        TooltipManager.Instance.UpdatePosition(Input.mousePosition);
    }

    public string GetTooltip() {
        return "";
    }
}
