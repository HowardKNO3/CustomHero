using UnityEngine;
using static Constants;

[CreateAssetMenu(fileName = "NewActiveSkill", menuName = "Skills/ActiveSkill")]
public class ActiveSkill : Skill
{
    public float[] damageAmount = new float[ATTRIBUTE_TYPES];
    public float expMultiplier;

    public override void Activate(Character user, Character target)
    {
        // Logic for activating an active skill, such as instantiating effects
        Debug.Log(skillName + " activated by " + user.name);
        target.TakeDamage(damageAmount[0]);
    }
}
