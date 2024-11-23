using System.Runtime.InteropServices;
using UnityEngine;
[CreateAssetMenu(fileName = "TargetHealthCondition", menuName = "Condition/TargetHealthCondition")]
public class TargetHealthCondition : Condition {
    public double minValue;
    public double maxValue;
    public override bool CheckIfMet(Character actor, Character target) {
        double healthPercentage = target.Health / target.characterData.maxHealth * 100;
        return healthPercentage >= minValue && healthPercentage <= maxValue;
    }
}