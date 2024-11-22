using UnityEngine;
using static Constants;

[CreateAssetMenu(fileName = "HealthEffect", menuName = "Effect/HealthEffect")]

class HealthEffect : Effect {
    public int attributeIndex;
    public bool isHeal;
    public bool isPeriodic;
    public float attributePercentage;

    public override bool IsBuff()
    {
        return isPeriodic && !isHeal;
    }
}