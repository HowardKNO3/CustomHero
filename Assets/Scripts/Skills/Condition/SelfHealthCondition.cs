using UnityEngine;
[CreateAssetMenu(fileName = "SelfHealthCondition", menuName = "Condition/SelfHealthCondition")]
public class SelfHealthCondition : Condition {
    public double minValue;
    public double maxValue;
    public override bool CheckIfMet(Character actor, Character target) {
        double healthPercentage = actor.Health / actor.MaxHealth * 100;
        return healthPercentage >= minValue && healthPercentage <= maxValue;
    }
}