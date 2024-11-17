using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class Character : MonoBehaviour
{
    float[] skillFills = new float[MAX_SKILL_COUNT];

    float health;

    public SkillManager skillManager;
    public CharacterData characterData;

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
        for (int i = 0; i < GetSkillCount(); i++) {
            Skill skill = skillManager.GetSkillById(characterData.skillIds[i]);
            skillFills[i] += BASIC_SKILL_SPEED / skill.cooldown * Time.deltaTime;
            if (skillFills[i] >= 1) {
                skillManager.ActivateSkill(characterData.skillIds[i], this, this);
                skillFills[i] = 0;
            }
        }
        
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
        for (int i = 0; i < ATTRIBUTE_TYPES; i++) {
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

    public void PrintCharacterInfo() {
        Debug.Log("Health: " + health
        + "\nMax Health: " + characterData.maxHealth
        + "\nAttribute Levels: " + characterData.AttributeLevelsToString()
        + "\nAttribute Powerups: " + characterData.AttributePowerupsToString()
        + "\nSkill Ids: " + characterData.SkillIdsToString());
    }
}
