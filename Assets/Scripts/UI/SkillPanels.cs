using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Constants;

public class SkillPanels : MonoBehaviour
{
    public SkillPanel[] skillPanels;
    public void UpdateUI(Character character) {
        for (int i = 0; i < MAX_SKILL_COUNT; i++) {
            skillPanels[i].UpdatePanel(character);
        }
    }
}
