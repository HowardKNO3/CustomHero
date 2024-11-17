using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static Constants;
using System;

[CreateAssetMenu(fileName = "NewCharacterData", menuName = "Characters/Character")]
public class CharacterData : ScriptableObject {
    public int[] skillIds = new int[MAX_SKILL_COUNT];
    public int[] attributeLevels = new int[ATTRIBUTE_TYPES];
    public float[] attributeExps = new float[ATTRIBUTE_TYPES];
    public int[] attributePowerups = new int[ATTRIBUTE_TYPES];
    public float maxHealth;


    public string AttributeLevelsToString() {
        string ret = "[";
        for (int i = 0; i < ATTRIBUTE_TYPES; i++) {
            ret += attributeLevels[i].ToString();
            ret += ", ";
        }
        ret += "]";
        return ret;
    }
    public string AttributePowerupsToString() {
        string ret = "[";
        for (int i = 0; i < ATTRIBUTE_TYPES; i++) {
            ret += attributePowerups[i].ToString();
            ret += ", ";
        }
        ret += "]";
        return ret;
    }
    public string SkillIdsToString() {
        string ret = "[";
        for (int i = 0; i < MAX_SKILL_COUNT; i++) {
            ret += skillIds[i].ToString();
            ret += ", ";
        }
        ret += "]";
        return ret;
    }
}