using UnityEngine;
using UnityEngine.Assertions.Must;
public class Condition : ScriptableObject {
    public virtual bool CheckIfMet(Character actor, Character target) {
        return false;
    }
}