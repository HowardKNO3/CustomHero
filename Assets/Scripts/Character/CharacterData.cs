using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static Constants;
using System;

[CreateAssetMenu(fileName = "NewCharacterData", menuName = "Characters/Character")]
public class CharacterData : ScriptableObject {
    public Skill[] skills = new Skill[MAX_SKILL_COUNT];
    public int[] attributeLevels = new int[MAX_ATTRIBUTE_TYPES];
    public double[] attributeExperiences = new double[MAX_ATTRIBUTE_TYPES];
    public int[] attributePowerups = new int[MAX_ATTRIBUTE_TYPES];
    public double maxHealth;

    public int GetSkillCount() {
        int i = 0;
        while (i < MAX_SKILL_COUNT && skills[i] != null) i++;
        return i;
    }

    public string AttributeLevelsToString() {
        string ret = "[";
        for (int i = 0; i <MAX_ATTRIBUTE_TYPES; i++) {
            ret += attributeLevels[i].ToString();
            ret += ", ";
        }
        ret += "]";
        return ret;
    }
    public string AttributePowerupsToString() {
        string ret = "[";
        for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
            ret += attributePowerups[i].ToString();
            ret += ", ";
        }
        ret += "]";
        return ret;
    }
    public string SkillsToString() {
        string ret = "[";
        for (int i = 0; i < MAX_SKILL_COUNT; i++) {
            ret += skills[i];
            ret += ", ";
        }
        ret += "]";
        return ret;
    }
}