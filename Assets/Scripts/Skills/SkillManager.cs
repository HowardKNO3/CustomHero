using UnityEngine;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }
    [SerializeField] SkillDatabase skillDatabase;

    void Awake() {
        if (Instance != null && Instance != this) {
            Debug.LogWarning("SkillManager: " +
            "Duplicate instance detected and removed. Only one instance of SkillManager is allowed.");
            Destroy(Instance);
            return;
        }
        Instance = this;
    }

    public Effect ActivateSkill(int skillId, Character user, Character target)
    {
        Skill skill = skillDatabase.GetSkillById(skillId);
        if (skill != null) {
            return skill.Activate(user, target);
        } else {
            return null;
        }
    }

    public Skill GetSkillById(int skillId) {
        return skillDatabase.GetSkillById(skillId);
    }
    
    public int GetSkillCount() {
        return skillDatabase.skills.Length;
    }
}
