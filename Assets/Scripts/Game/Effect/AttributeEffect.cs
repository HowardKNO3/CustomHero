using UnityEngine;
using static Constants;

[CreateAssetMenu(fileName = "AttributeEffect", menuName = "Effect/AttributeEffect")]

public class AttributeEffect : Effect {
    public int attributeIndex;
    public int effectValue;

    public override bool IsBuff()
    {
        return effectValue > 0;
    }
}