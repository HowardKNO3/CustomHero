using System.Runtime.InteropServices;
using UnityEngine;
using static Constants;
[CreateAssetMenu(fileName = "NewLevel", menuName = "Levels/Level")]
public class Level : ScriptableObject {
    public string levelName;
    public CharacterData levelBoss;
    public double enemyExperience;
    public CharacterData GenerateEnemyData(bool isBoss) {
        if (isBoss) return levelBoss;
        CharacterData generatedEnemyData = (CharacterData)CreateInstance("CharacterData");
        generatedEnemyData.maxHealth = BASE_ENEMY_CHARACTER_HEALTH;
        for (int i = 0; i < MAX_SKILL_COUNT; i++) {
            Skill skill;
            while (true) {
                skill = SkillManager.Instance.GetRandomSkill();
                if (!generatedEnemyData.IsLearned(skill)) {
                    break;
                }
            }
            generatedEnemyData.skills[i] = skill;
        }
        double[] attributeExperiencePercentage = GeneratePercentage();
        for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
            double attributeExperience = attributeExperiencePercentage[i] * enemyExperience * 0.01;
            generatedEnemyData.GainExperienceInstant(attributeExperience, i);
        }
        return generatedEnemyData;
    }
    double[] GeneratePercentage() {

        int num1 = Random.Range(0, 101);
        int num2 = Random.Range(0, 101);

        int lower = Mathf.Min(num1, num2);
        int upper = Mathf.Max(num1, num2);

        int a = lower;
        int b = upper - lower;
        int c = 100 - upper;
        Debug.Log(a + " " + b + " " + c);
        return new double[] { a, b, c };
    }

    
}