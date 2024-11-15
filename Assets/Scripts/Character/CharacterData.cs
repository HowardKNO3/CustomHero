using UnityEngine;
using static Constants;

[CreateAssetMenu(fileName = "NewCharacterData", menuName = "Characters/Character")]
public class CharacterData : ScriptableObject {
    public int[] skillIds = new int[MAX_SKILL_COUNT];
    public int[] attributeLevels = new int[ATTRIBUTE_TYPES];
    public int[] attributePowerups = new int[ATTRIBUTE_TYPES];
    public float maxHealth;
}