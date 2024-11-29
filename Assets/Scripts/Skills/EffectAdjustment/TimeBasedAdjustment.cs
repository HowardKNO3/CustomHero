using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Adjustments/Time-Based Adjustment")]
public class TimeBasedAdjustment : EffectAdjustment
{
    
    public AnimationCurve adjustmentCurve;
    

    public override float CalculateAdjustValue(Character actor, Character target)
    {
        Character character = useTarget ? target : actor;
        if (character == null) return 1f;

        float time = (float)((BattleManager)BattleManager.Instance).BattleTime;
        return Mathf.Lerp(minMultiplier, maxMultiplier, adjustmentCurve.Evaluate(time));
    }
}