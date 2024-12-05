using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Adjustments/Time-Based Adjustment")]
public class TimeBasedAdjustment : EffectAdjustment
{
    
    public AnimationCurve adjustmentCurve;
    

    public override float CalculateAdjustValue(Character actor, Character target) {
        float time = (float)BattleManager.Instance.BattleTime;
        // Debug.Log(time + " " + Mathf.Lerp(minMultiplier, maxMultiplier, adjustmentCurve.Evaluate(time)));
        return Mathf.Lerp(minMultiplier, maxMultiplier, adjustmentCurve.Evaluate(time));
    }
}