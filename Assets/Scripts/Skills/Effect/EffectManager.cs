using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

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
        EffectInstance effectInstance = new(actor, target, effect);
        effectInstance.SetCharacter(actor, target);
        if (onSelf) {
            actor.appliedEffect.Add(effectInstance);
        }
        else {
            target.appliedEffect.Add(effectInstance);
        }
        if (effectInstance.effect.hasDuration) {
            effectInstance.SetTimer();
        }
    }

    public void HandleHealthEffect(Character character) {
        List<EffectInstance> effects = character.appliedEffect;
        List<EffectInstance> usedEffects = new();
        foreach (var effectInstance in effects) {
            if (effectInstance.effect is HealthEffect healthEffect) {
                if (!effectInstance.IsConditionMet()) {
                    if (!effectInstance.effect.hasDuration) usedEffects.Add(effectInstance);
                    continue;
                }
                double amount = CalculateAmount(healthEffect);

                if (healthEffect.hasDuration) {
                    amount *= Time.deltaTime;
                } else {
                    usedEffects.Add(effectInstance);
                }

                if (!healthEffect.isHeal) {
                    character.TakeDamage(amount);
                } else {
                    character.Heal(amount);
                }
                if (IsEffective(effectInstance, character)) {
                    effectInstance.actor.UpdateBattleResult(amount, healthEffect.attributeIndex, healthEffect.isHeal);
                }

            }
        }
        RemoveEffect(character.appliedEffect, usedEffects);
    }

    bool IsEffective(EffectInstance effectInstance, Character character) {
        return (effectInstance.actor != character) != ((HealthEffect)effectInstance.effect).isHeal;
    }
    

    double CalculateAmount(HealthEffect effect) {
        return effect.attributePercentage;
    }

    public void UpdateEffectTimer(Character character) {
        List<EffectInstance> endedEffects = new();
        foreach (var effectInstance in character.appliedEffect) {
            if (effectInstance.effect.hasDuration) {
                effectInstance.UpdateTimer(Time.deltaTime);
            }
            if (effectInstance.HasEnded()) {
                endedEffects.Add(effectInstance);
            }
        }
        RemoveEffect(character.appliedEffect, endedEffects);
    }

    public void RemoveEffect(List<EffectInstance> appliedEffects, List<EffectInstance> removedEffects) {
        foreach (var removedEffect in removedEffects) {
            appliedEffects.Remove(removedEffect);
        }
    }
}
