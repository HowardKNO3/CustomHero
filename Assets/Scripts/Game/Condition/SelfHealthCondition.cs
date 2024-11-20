using UnityEngine;
[CreateAssetMenu(fileName = "SelfHealthCondition", menuName = "Condition/SelfHealthCondition")]
public class SelfHealthCondition : Condition {
    public float minValue;
    public float maxValue;
    public override bool CheckIfMet(Character actor, Character target) {
        float healthPercentage = actor.Health / actor.characterData.maxHealth * 100;
        return healthPercentage >= minValue && healthPercentage <= maxValue;
    }
}