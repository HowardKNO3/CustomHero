using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
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

    public virtual string GetTooltip() {
        return null;
    }
}
