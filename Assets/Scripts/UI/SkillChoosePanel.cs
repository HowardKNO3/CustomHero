using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillChoosePanel : MonoBehaviour
{
    public TextMeshProUGUI skillNameText;
    public void DisplaySkill(int skillId) {
        string skillName = SkillManager.Instance.GetSkillById(skillId).skillName;
        skillNameText.text = skillName;
    }
}
