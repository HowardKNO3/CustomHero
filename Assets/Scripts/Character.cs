using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    int[] skillIds = new int[MAX_SKILL_COUNT];
    int skillCount;
    float health;
    float[] skillFills = new float[MAX_SKILL_COUNT];


    public SkillManager skillManager;
    public CharacterData characterData;
    
    public int[] SkillIds {
        get {return skillIds;}
        set {skillIds = value;}
    }

    public int SkillCount {
        get {return skillCount;}
        set {skillCount = value;}
    }

    public float Health {
        get {return health;}
        set {health = value;}
    }

    public float[] SkillFills {
        get {return skillFills;}
        set {skillFills = value;}
    }
    
    void Start()
    {
        health = characterData.maxHealth;
        skillCount = 0;
        for (int i = 0; i < MAX_SKILL_COUNT; i++) {
            if (characterData.skillIds[i] != 0) {
                skillCount++;
                skillIds[i] = characterData.skillIds[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        print(health);
        for (int i = 0; i < skillCount; i++) {
            Skill skill = skillManager.skillDatabase.GetSkillById(skillIds[i]);
            skillFills[i] += BASIC_SKILL_SPEED / skill.cooldown * Time.deltaTime;
            if (skillFills[i] >= 1) {
                skillManager.ActivateSkill(skillIds[i], this, this);
                skillFills[i] = 0;
            }
        }
        
    }
    public int GetSkillCount() {
        return skillCount;
    }
    public void TakeDamage(float damage) {
        health -= damage;
    }
}
