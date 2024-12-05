using UnityEngine;
using static Constants;

[CreateAssetMenu(fileName = "DispelEffect", menuName = "Effect/DispelEffect")]

class DispelEffect : Effect {
    public int dispelAmount;
    public override bool IsBuff()
    {
        return false;
    }
}