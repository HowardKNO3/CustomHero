using UnityEngine;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour
{
    public SkillDatabase skillDatabase;
    private Dictionary<string, float> cooldowns = new Dictionary<string, float>();

    public void ActivateSkill(int skillId, Character user, Character target)
    {
        Skill skill = skillDatabase.GetSkillById(skillId);
        if (skill != null)
        {
            skill.Activate(user, target);
        }
    }

    
}
