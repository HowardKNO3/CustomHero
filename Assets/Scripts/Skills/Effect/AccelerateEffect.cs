using UnityEngine;
using static Constants;

[CreateAssetMenu(fileName = "AccelerateEffect", menuName = "Effect/AccelerateEffect")]

class AccelerateEffect : Effect {
    public int accelerateAmount;
    public override bool IsBuff()
    {
        return true;
    }
}