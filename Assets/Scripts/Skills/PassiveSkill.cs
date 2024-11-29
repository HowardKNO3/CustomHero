using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewPassiveSkill", menuName = "Skills/PassiveSkill")]
public class PassiveSkill : Skill {
    public override void Activate(Character user, Character target) {
        base.Activate(user, target);
    }
}
