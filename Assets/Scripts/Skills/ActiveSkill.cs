using UnityEngine;
using static Constants;

[CreateAssetMenu(fileName = "NewActiveSkill", menuName = "Skills/ActiveSkill")]
public class ActiveSkill : Skill
{
    public float[] damageAmount = new float[MAX_ATTRIBUTE_TYPES];
    

    public override Effect Activate(Character user, Character target)
    {
        Effect effect = new Effect();
        for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
            effect.damage[i] = target.TakeDamage(damageAmount[i]);
        }
        return effect;
        
    }
}
