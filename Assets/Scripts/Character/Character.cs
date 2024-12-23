using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;
using static Utils;

public class BattleResult {
    public double[] totalDamageAmount = new double[MAX_ATTRIBUTE_TYPES];
    public double[] totalHealAmount = new double[MAX_ATTRIBUTE_TYPES];
}


public class Character : MonoBehaviour
{
    double[] skillFills = new double[MAX_SKILL_COUNT];
    int[] skillUsageCounts = new int[MAX_SKILL_COUNT];
    [HideInInspector] public double[] gainExperienceAmount = new double[MAX_ATTRIBUTE_TYPES];

    double health;
    public CharacterData characterData;
    
    [HideInInspector] public List<EffectInstance> appliedEffect = new List<EffectInstance>();
    [HideInInspector] public BattleResult battleResult;

    public bool IsVictory {get{return health > 0;}}

    public double[] SkillFills {
        get {return skillFills;}
    }
    public int[] SkillUsageCounts {
        get {return skillUsageCounts;}
    }

    public double Health {
        get {return health;}
        set {health = value;}
    }

    public double[] HealthEffectAmount {
        get {
            double[] ret = new double[MAX_ATTRIBUTE_TYPES];
            for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) ret[i] = CalculateHealthEffectAmount(i);
            return ret;
        }
    }

    

    public double MaxHealth {
        get {return characterData.maxHealth;}
        set {characterData.maxHealth = value;}
    }

    public double[] AttributeExperienceRequirements {
        get {
            double[] ret = new double[MAX_ATTRIBUTE_TYPES];
            for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) ret[i] = characterData.GetExperienceRequirement(i);
            return ret;
        }
    }

    public int[] AttributeLevels {
        get {return characterData.attributeLevels;}
    }

    public double[] AttributeExperiences {
        get {return characterData.attributeExperiences;}
    }

    public int[] AttributePowerups {
        get {return characterData.attributePowerups;}
    }

    
    public Skill[] Skills {
        get {return characterData.skills;}
    }

    public void BattleReset(bool isEnemy) {
        skillFills = new double[MAX_SKILL_COUNT];
        skillUsageCounts = new int[MAX_SKILL_COUNT];
        appliedEffect = new();
        battleResult = new();
        if (isEnemy) health = MaxHealth;
    }
    

    void Start()
    {
        health = MaxHealth;
    }
    public void ProgressSkill() {
        for (int i = 0; i < GetSkillCount(); i++) {
            if (Skills[i] is not ActiveSkill) continue;
            ActiveSkill skill = (ActiveSkill)Skills[i];
            skillFills[i] += BASE_SKILL_SPEED / skill.cooldown * Time.deltaTime;
        }
    }
    public bool IsSkillReady(int skillIndex) {
        return skillFills[skillIndex] >= 1;
    }
    public void EnterCooldown(int skillIndex) {
        skillFills[skillIndex] = 0;
    }
    public int GetSkillCount() {
        return characterData.GetSkillCount();
    }
    public void TakeDamage(double damage) {
        health -= damage;
    }
    public void Heal(double amount) {
        health = Math.Min(health + amount, MaxHealth);
    }
    public void GetPowerup(int[] powerups) {
        for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
            AttributePowerups[i] += powerups[i];
        }
    }

    public void LearnSkill(Skill skill, int skillIndex) {
        Skills[skillIndex] = skill;
    }

    public bool IsLearned(Skill skill) {
        return characterData.IsLearned(skill);
    }

    public void UpdateBattleResult(double amount, int attributeIndex, bool isHeal) {
        if (isHeal) {
            battleResult.totalHealAmount[attributeIndex] += amount;
        } else {
            battleResult.totalDamageAmount[attributeIndex] += amount;
        }
    }

    public void CalculateExperience() {
        for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
            gainExperienceAmount[i] = battleResult.totalDamageAmount[i] + battleResult.totalHealAmount[i];
        }
    }

    public void GainExperience(double amount, int attributeIndex) {
        double gainAmount = Math.Min(amount, gainExperienceAmount[attributeIndex]);
        gainExperienceAmount[attributeIndex] -= gainAmount;
        characterData.GainExperienceInstant(gainAmount, attributeIndex);
    }

    public void PrintCharacterInfo() {
        Debug.Log("Health: " + health
        + "\nMax Health: " + characterData.maxHealth
        + "\nAttribute Levels: " + characterData.AttributeLevelsToString()
        + "\nAttribute Experiences: " + characterData.AttributeExperiencesToString()
        + "\nAttribute Powerups: " + characterData.AttributePowerupsToString()
        + "\nSkills: " + characterData.SkillsToString());
    }
    

    double CalculateHealthEffectAmount(int attributeIndex) {
        return BASE_HEALTH_EFFECT_AMOUNT * CalculateMultiplier(AttributeLevels[attributeIndex], LIN_FACTOR_EFFECT, EXP_FACTOR_EFFECT);
    }
    
}
