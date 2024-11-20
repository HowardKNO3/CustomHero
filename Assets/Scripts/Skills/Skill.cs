using UnityEngine;
using static Constants;
public class Effect {
    public Skill skill;
    public float[] damage = new float[MAX_ATTRIBUTE_TYPES];
}

[CreateAssetMenu(fileName = "NewSkill", menuName = "Skills/Skill")]
public class Skill : ScriptableObject {
    public int id;
    public string skillName;
    public float cooldown;
    public string description;
    public virtual Effect Activate(Character user, Character target)
    {
        return null;
    }
}

