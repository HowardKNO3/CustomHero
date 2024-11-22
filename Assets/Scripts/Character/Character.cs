using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class BattleResult {
    public float[] totalDamageAmount = new float[MAX_ATTRIBUTE_TYPES];
    public float[] totalHealAmount = new float[MAX_ATTRIBUTE_TYPES];
}


public class Character : MonoBehaviour
{
    float[] skillFills = new float[MAX_SKILL_COUNT];
    [HideInInspector] public double[] getExperienceAmount = new double[MAX_ATTRIBUTE_TYPES];

    float health;
    public CharacterData characterData;

    [HideInInspector] public List<EffectInstance> appliedEffect = new List<EffectInstance>();
    [HideInInspector] public BattleResult battleResult;

    public float[] SkillFills {
        get {return skillFills;}
        set {skillFills = value;}
    }

    public float Health {
        get {return health;}
        set {Health = value;}
    }

    public void BattleReset(bool isEnemy) {
        skillFills = new float[MAX_SKILL_COUNT];
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
            skillFills[i] += (float)BASE_SKILL_SPEED / skill.cooldown * Time.deltaTime;
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
    public void TakeDamage(float damage) {
        health -= damage;
    }
    public void Heal(float amount) {
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

    public void UpdateBattleResult(float amount, int attributeIndex, bool isHeal) {
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

    public void GetExperience(float amount, int attributeIndex) {
        double[] attributeExperiences = characterData.attributeExperiences;
        double getAmount = Math.Min(amount, getExperienceAmount[attributeIndex]);
        attributeExperiences[attributeIndex] += getAmount;
        getExperienceAmount[attributeIndex] -= getAmount;
        if (attributeExperiences[attributeIndex] > BASE_UPGRADE_EXPERIENCE) {
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
