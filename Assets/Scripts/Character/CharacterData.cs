using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static Constants;
using static Utils;
using System;
using System.Runtime.InteropServices;

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
    public double GetExperienceRequirement(int attributeIndex) {
        return BASE_EXP_REQUIREMENT * CalculateMultiplier(attributeLevels[attributeIndex], LIN_FACTOR_EXP, EXP_FACTOR_EXP);
    }
    public bool IsLearned(Skill skill) {
        for (int i = 0; i < GetSkillCount(); i++) {
            if (skill == skills[i]) return true;
        }
        return false;
    }

    public string AttributeLevelsToString() {
        string ret = "[";
        for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
            ret += attributeLevels[i].ToString();
            ret += ", ";
        }
        ret += "]";
        return ret;
    }
    public string AttributeExperiencesToString() {
        string ret = "[";
        for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
            ret += attributeExperiences[i].ToString();
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
    public void GainExperienceInstant(double amount, int attributeIndex) {
        double requirement = GetExperienceRequirement(attributeIndex);
        attributeExperiences[attributeIndex] += amount;
        while (attributeExperiences[attributeIndex] > requirement) {
            attributeLevels[attributeIndex]++;
            attributeExperiences[attributeIndex] -= requirement;
            requirement = GetExperienceRequirement(attributeIndex);
        }
    }

}