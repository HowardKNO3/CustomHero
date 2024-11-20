using System.Runtime.InteropServices;
using UnityEngine;
[CreateAssetMenu(fileName = "TargetHealthCondition", menuName = "Condition/TargetHealthCondition")]
public class TargetHealthCondition : Condition {
    public float minValue;
    public float maxValue;
    public override bool CheckIfMet(Character actor, Character target) {
        float healthPercentage = target.Health / target.characterData.maxHealth * 100;
        return healthPercentage >= minValue && healthPercentage <= maxValue;
    }
}