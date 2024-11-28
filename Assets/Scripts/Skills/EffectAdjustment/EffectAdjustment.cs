using UnityEngine;

public class EffectAdjustment : ScriptableObject {
    public float minMultiplier;
    public float maxMultiplier;
    public bool useTarget;
    public virtual float CalculateMultiplier(Character actor, Character target) {
        return 0;
    }

    
}