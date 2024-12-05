using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Adjustments/Health-Based Adjustment")]
public class HealthBasedAdjustment : EffectAdjustment
{
    
    public AnimationCurve adjustmentCurve;
    
    
    public override float CalculateAdjustValue(Character actor, Character target)
    {
        Character character = useTarget ? target : actor;
        if (character == null) return 1f;

        float time = Mathf.Clamp01((float)character.Health / (float)character.MaxHealth);
        return Mathf.Lerp(minMultiplier, maxMultiplier, adjustmentCurve.Evaluate(time));
    }
}