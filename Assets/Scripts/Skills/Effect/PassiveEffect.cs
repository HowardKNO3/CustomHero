using UnityEngine;
[CreateAssetMenu(fileName = "PassiveEffect", menuName = "Effect/PassiveEffect")]
public class PassiveEffect : Effect {
    public Effect[] applySelfEffect;
    public Effect[] applyTargetEffect;
    public bool onlyOnce;
}