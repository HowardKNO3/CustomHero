using UnityEngine;

public class Effect : ScriptableObject {
    public double duration;
    public bool dispellable;
    public bool hasDuration;
    public EffectAdjustment amountAdjustment;
    public EffectAdjustment countAdjustment;
    public virtual bool IsBuff() {
        return false;
    }

    
}

public class EffectInstance {
    
    [HideInInspector] public Character actor;
    [HideInInspector] public Character target;
    [HideInInspector] public Effect effect;
    

    public EffectInstance(Character actor, Character target, Effect effect) {
        this.actor = actor;
        this.target = target;
        this.effect = effect;
    }

    double remainingDuration;
    public void SetCharacter(Character actor, Character target) {
        this.actor = actor;
        this.target = target;
    }
    public void UpdateTimer(double deltaTime) {
        if (remainingDuration > 0) remainingDuration -= deltaTime;
    }
    public void SetTimer() {
        remainingDuration = effect.duration;
    }
    public void AddTimer(double time) {
        remainingDuration += time;
    }

    public bool HasEnded() {
        return effect.hasDuration && remainingDuration <= 0;
    }

    public double GetAmountMultiplier() {
        double multiplier = effect.amountAdjustment != null ? effect.amountAdjustment.CalculateAdjustValue(actor, target) : 1f;
        return multiplier;
    }

    public double GetCountMultiplier() {
        double multiplier = effect.countAdjustment != null ? effect.countAdjustment.CalculateAdjustValue(actor, target) : 1f;
        return multiplier;
    }

}