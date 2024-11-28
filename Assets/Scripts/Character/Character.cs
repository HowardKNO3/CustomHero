using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class BattleResult {
    public double[] totalDamageAmount = new double[MAX_ATTRIBUTE_TYPES];
    public double[] totalHealAmount = new double[MAX_ATTRIBUTE_TYPES];
}


public class Character : MonoBehaviour
{
    double[] skillFills = new double[MAX_SKILL_COUNT];
    [HideInInspector] public double[] gainExperienceAmount = new double[MAX_ATTRIBUTE_TYPES];

    double health;
    public CharacterData characterData;

    [HideInInspector] public List<EffectInstance> appliedEffect = new List<EffectInstance>();
    [HideInInspector] public BattleResult battleResult;

    public double[] SkillFills {
        get {return skillFills;}
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
            for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) ret[i] = GetExperienceRequirement(i);
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
        for (int i = 0; i < GetSkillCount(); i++) {
            if (skill == Skills[i]) return true;
        }
        return false;
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
        double requirement = AttributeExperienceRequirements[attributeIndex];
        AttributeExperiences[attributeIndex] += gainAmount;
        gainExperienceAmount[attributeIndex] -= gainAmount;
        while (AttributeExperiences[attributeIndex] > requirement) {
            AttributeLevels[attributeIndex]++;
            AttributeExperiences[attributeIndex] -= requirement;
            requirement = AttributeExperienceRequirements[attributeIndex];
        }
    }

    public void PrintCharacterInfo() {
        Debug.Log("Health: " + health
        + "\nMax Health: " + characterData.maxHealth
        + "\nAttribute Levels: " + characterData.AttributeLevelsToString()
        + "\nAttribute Powerups: " + characterData.AttributePowerupsToString()
        + "\nSkills: " + characterData.SkillsToString());
    }
    public double GetExperienceRequirement(int attributeIndex) {
        return BASE_EXP_REQUIREMENT * CalculateMultiplier(AttributeLevels[attributeIndex], LIN_FACTOR_EXP, EXP_FACTOR_EXP);
    }

    double CalculateHealthEffectAmount(int attributeIndex) {
        return BASE_HEALTH_EFFECT_AMOUNT * CalculateMultiplier(AttributeLevels[attributeIndex], LIN_FACTOR_EFFECT, EXP_FACTOR_EFFECT);
    }
    double CalculateMultiplier(int level, double linearFactor, double exponentialFactor) {
        double mul = 1;
        for (int i = 0; i < level; i++) {
            mul += linearFactor;
            mul *= exponentialFactor;
        }
        return mul;
    }
}
