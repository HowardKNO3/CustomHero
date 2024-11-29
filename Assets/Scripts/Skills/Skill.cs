using UnityEngine;
using static Constants;
public class SkillResult {
    public double[] damage = new double[MAX_ATTRIBUTE_TYPES];
}

[CreateAssetMenu(fileName = "NewSkill", menuName = "Skills/Skill")]
public class Skill : ScriptableObject {
    public string skillName;
    public string description;
    public Effect[] applySelfEffect;
    public Effect[] applyTargetEffect;

    
    public virtual void Activate(Character user, Character target)
    {
        
        foreach (var effect in applySelfEffect) {
            EffectAdjustment adjustment = effect.countAdjustment;
            int applyCount = (adjustment == null) ? 1 : (int)adjustment.CalculateAdjustValue(user, target);
            for (int i = 0; i < applyCount; i++) {
                EffectManager.Instance.ApplyEffect(user, target, true, effect);
            }
        }
        foreach (var effect in applyTargetEffect) {
            EffectAdjustment adjustment = effect.countAdjustment;
            int applyCount = (adjustment == null) ? 1 : (int)adjustment.CalculateAdjustValue(user, target);
            for (int i = 0; i < applyCount; i++) {
                EffectManager.Instance.ApplyEffect(user, target, false, effect);
            }
        }
    }
}

