using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class Character : MonoBehaviour
{
    float[] skillFills = new float[MAX_SKILL_COUNT];

    float health;
    public CharacterData characterData;

    [HideInInspector] public List<EffectInstance> appliedEffect = new List<EffectInstance>();

    

    public float[] SkillFills {
        get {return skillFills;}
        set {skillFills = value;}
    }

    public float Health {
        get {return health;}
        set {Health = value;}
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
            skillFills[i] += BASIC_SKILL_SPEED / skill.cooldown * Time.deltaTime;
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
    public float TakeDamage(float damage) {
        health -= damage;
        return damage;
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

    public void GetExperience(SkillResult skillResult) {
        for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
            characterData.attributeExps[i] += skillResult.damage[i];
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
