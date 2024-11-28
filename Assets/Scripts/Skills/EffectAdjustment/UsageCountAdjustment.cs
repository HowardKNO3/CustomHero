using System.Runtime.InteropServices;
using UnityEngine;
using static Constants;

[CreateAssetMenu(menuName = "Effect/Adjustments/Usage Count Adjustment")]
public class UsageCountAdjustment : EffectAdjustment
{
    
    public AnimationCurve adjustmentCurve;
    public bool calculateAll;
    public Skill skill;

    public override float CalculateMultiplier(Character actor, Character target)
    {
        Character character = useTarget ? target : actor;
        if (character == null) return 1f;
        int usageCount = 0;
        for (int i = 0; i < MAX_SKILL_COUNT; i++) {
            if (!calculateAll && character.Skills[i] != skill) continue;
            usageCount += character.SkillUsageCounts[i];
        }
        float time = usageCount;
        
        Debug.Log(time + " " + Mathf.Lerp(minMultiplier, maxMultiplier, adjustmentCurve.Evaluate(usageCount)));
        return Mathf.Lerp(minMultiplier, maxMultiplier, adjustmentCurve.Evaluate(usageCount));
    }
}