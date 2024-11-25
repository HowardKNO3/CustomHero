using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
interface ITippedObject : IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler{
    string GetTooltip();
    
}

