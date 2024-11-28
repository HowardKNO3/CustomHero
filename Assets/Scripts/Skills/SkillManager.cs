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

    public void ActivateSkill(Skill skill, Character user, Character target) {
        if (skill != null) {
            skill.Activate(user, target);
        }
    }
    public Skill GetSkillByIndex(int index) {
        return skillDatabase.GetSkillByIndex(index);
    }
    public int GetSkillCount() {
        return skillDatabase.skills.Length;
    }
}
