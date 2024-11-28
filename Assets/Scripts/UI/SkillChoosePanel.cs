using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillChoosePanel : MonoBehaviour
{
    public TextMeshProUGUI skillNameText;
    public void DisplaySkill(Skill skill) {
        string skillName = skill.skillName;
        skillNameText.text = skillName;
    }
}
