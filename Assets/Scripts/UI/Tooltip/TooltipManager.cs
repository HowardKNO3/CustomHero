using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class TooltipManager : MonoBehaviour
{
    public GameObject tooltip;
    public TextMeshProUGUI tooltipText;
    
    public static TooltipManager Instance {get; private set;}
    RectTransform rectTransform;

    void Awake() {
        if (Instance != null && Instance != this) {
            Debug.LogWarning("ToolTipManager: " +
            "Duplicate instance detected and removed. Only one instance of ToolTipManager is allowed.");
            Destroy(Instance);
            return;
        }
        Instance = this;
        rectTransform = tooltip.GetComponent<RectTransform>();
        Vector2 pivot = new Vector2(0f, 0f); // Bottom-left pivot
        rectTransform.pivot = pivot;
        tooltip.SetActive(false);
    }

    public void ShowTip(string text) {
        tooltipText.text = text;
        tooltip.SetActive(true);
    }

    public void HideTip() {
        tooltip.SetActive(false);
    }

    public void UpdatePosition(Vector2 position) {
        Vector2 pivot = new Vector2(0f, 0f);
        rectTransform.pivot = pivot;
        Vector2 offset = new Vector2(10f, 10f);
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        
        Vector2 tooltipSize = rectTransform.sizeDelta;
        Vector2 tooltipPosition = position + offset;

        // Adjust position to prevent the tooltip from going off-screen
        if (tooltipPosition.x + tooltipSize.x > screenSize.x) // Right boundary
        {
            tooltipPosition.x = screenSize.x - tooltipSize.x;
        }
        if (tooltipPosition.y + tooltipSize.y > screenSize.y) // Top boundary
        {
            tooltipPosition.y = screenSize.y - tooltipSize.y;
        }
        if (tooltipPosition.x < 0) // Left boundary
        {
            tooltipPosition.x = 0;
        }
        if (tooltipPosition.y < 0) // Bottom boundary
        {
            tooltipPosition.y = 0;
        }

        tooltip.transform.position = tooltipPosition;
        AdjustTooltipSize();
    }
    void AdjustTooltipSize()
    {
        float preferredHeight = tooltipText.preferredHeight;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, preferredHeight);
    }
}
