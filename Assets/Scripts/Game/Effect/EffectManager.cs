using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }
    void Awake() {
        if (Instance != null && Instance != this) {
            Debug.LogWarning("EffectManager: " +
            "Duplicate instance detected and removed. Only one instance of EffectManager is allowed.");
            Destroy(Instance);
            return;
        }
        Instance = this;
    }

    public void ApplyEffect(Character actor, Character target, bool onSelf, Effect effect) {
        effect.SetCharacter(actor, target);
        if (onSelf) actor.appliedEffect.Add(effect);
        else target.appliedEffect.Add(effect);
    }

    public void HandleInstantEffect(Character character) {
        List<Effect> effects = character.appliedEffect;
        List<Effect> usedEffects = new();
        foreach (var effect in effects) {
            if (effect is HealthEffect healthEffect && !healthEffect.isPeriodic) {
                usedEffects.Add(healthEffect);
                if (!healthEffect.IsConditionMet()) continue;
                float amount = CalculateAmount(healthEffect);
                if (!healthEffect.isHeal) character.TakeDamage(amount);
                else character.Heal(amount);
            }
        }
        foreach (var usedEffect in usedEffects) {
            effects.Remove(usedEffect);
        }
        
    }

    float CalculateAmount(HealthEffect effect) {
        return effect.attributePercentage;
    }
}
