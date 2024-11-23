using UnityEngine;
using static Constants;
public class SkillResult {
    public double[] damage = new double[MAX_ATTRIBUTE_TYPES];
}

[CreateAssetMenu(fileName = "NewSkill", menuName = "Skills/Skill")]
public class Skill : ScriptableObject {
    public int id;
    public string skillName;
    public string description;
    public Effect[] applySelfEffect;
    public Effect[] applyTargetEffect;

    
    public virtual void Activate(Character user, Character target)
    {
        foreach (var effect in applySelfEffect) {
            EffectManager.Instance.ApplyEffect(user, target, true, effect);
        }
        foreach (var effect in applyTargetEffect) {
            EffectManager.Instance.ApplyEffect(user, target, false, effect);
        }
    }
}

