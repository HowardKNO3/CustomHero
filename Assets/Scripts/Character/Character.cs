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
    [HideInInspector] public double[] getExperienceAmount = new double[MAX_ATTRIBUTE_TYPES];

    double health;
    public CharacterData characterData;

    [HideInInspector] public List<EffectInstance> appliedEffect = new List<EffectInstance>();
    [HideInInspector] public BattleResult battleResult;

    public double[] SkillFills {
        get {return skillFills;}
        set {skillFills = value;}
    }

    public double Health {
        get {return health;}
        set {Health = value;}
    }

    public void BattleReset(bool isEnemy) {
        skillFills = new double[MAX_SKILL_COUNT];
        appliedEffect = new();
        battleResult = new();
        if (isEnemy) health = characterData.maxHealth;
    }
    

    void Start()
    {
        health = characterData.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void ProgressSkill() {
        for (int i = 0; i < GetSkillCount(); i++) {
            ActiveSkill skill = (ActiveSkill)SkillManager.Instance.GetSkillById(characterData.skillIds[i]);
            skillFills[i] += (double)BASE_SKILL_SPEED / skill.cooldown * Time.deltaTime;
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
        health = Math.Min(health + amount, characterData.maxHealth);
    }
    public void GetPowerup(int[] powerups) {
        for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
            characterData.attributePowerups[i] += powerups[i];
        }
    }

    public void LearnSkill(int skillId, int skillIndex) {
        characterData.skillIds[skillIndex] = skillId;
    }

    public bool IsLearned(int skillId) {
        for (int i = 0; i < GetSkillCount(); i++) {
            if (skillId == characterData.skillIds[i]) return true;
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
            getExperienceAmount[i] = battleResult.totalDamageAmount[i] + battleResult.totalHealAmount[i];
        }
    }

    public void GetExperience(double amount, int attributeIndex) {
        double[] attributeExperiences = characterData.attributeExperiences;
        double getAmount = Math.Min(amount, getExperienceAmount[attributeIndex]);
        
        attributeExperiences[attributeIndex] += getAmount;
        getExperienceAmount[attributeIndex] -= getAmount;
        while (attributeExperiences[attributeIndex] > BASE_UPGRADE_EXPERIENCE) {
            characterData.attributeLevels[attributeIndex]++;
            attributeExperiences[attributeIndex] -= BASE_UPGRADE_EXPERIENCE;
        }
    }

    public void PrintCharacterInfo() {
        Debug.Log("Health: " + health
        + "\nMax Health: " + characterData.maxHealth
        + "\nAttribute Levels: " + characterData.AttributeLevelsToString()
        + "\nAttribute Powerups: " + characterData.AttributePowerupsToString()
        + "\nSkill Ids: " + characterData.SkillIdsToString());
    }
}
