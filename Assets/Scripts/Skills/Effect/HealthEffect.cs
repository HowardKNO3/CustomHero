using UnityEngine;
using static Constants;

[CreateAssetMenu(fileName = "HealthEffect", menuName = "Effect/HealthEffect")]

class HealthEffect : Effect {
    public int attributeIndex;
    
    public float attributePercentage;
    public bool isHeal;

    public override bool IsBuff()
    {
        return hasDuration && isHeal;
    }
}