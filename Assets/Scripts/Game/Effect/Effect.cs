using UnityEngine;

public class Effect : ScriptableObject {
    [HideInInspector] public Character actor;
    [HideInInspector] public Character target;
    public float duration;
    public bool dispellable;
    public Condition[] conditions;

    public void SetCharacter(Character actor, Character target) {
        this.actor = actor;
        this.target = target;
    }
    public virtual bool IsBuff() {
        return false;
    }

    public bool IsConditionMet() {
        foreach (var condition in conditions) {
            if (!condition.CheckIfMet(actor, target)) return false;
        }
        return true;
    }
}