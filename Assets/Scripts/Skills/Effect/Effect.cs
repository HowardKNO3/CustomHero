using UnityEngine;

public class Effect : ScriptableObject {
    public float duration;
    public bool dispellable;
    public Condition[] conditions;
    public bool hasDuration;

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

    float remainingDuration;
    public void SetCharacter(Character actor, Character target) {
        this.actor = actor;
        this.target = target;
    }
    public void UpdateTimer(float deltaTime) {
        if (remainingDuration > 0) remainingDuration -= deltaTime;
    }
    public void SetTimer() {
        remainingDuration = effect.duration;
    }
    public void AddTimer(float time) {
        remainingDuration += time;
    }

    public bool HasEnded() {
        return effect.hasDuration && remainingDuration <= 0;
    }

    public bool IsConditionMet() {
        foreach (var condition in effect.conditions) {
            if (!condition.CheckIfMet(actor, target)) return false;
        }
        return true;
    }
}