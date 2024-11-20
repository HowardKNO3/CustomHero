using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;
public class BattleManager : MonoBehaviour, PhaseManager
{
    
    public GameObject battleUI;
    public Character player;
    public Character enemy;
    Coroutine battleCoroutine;
    // Start is called before the first frame update
    public void StartPhase() {
        battleUI.SetActive(true);
        if (battleCoroutine != null)
            StopCoroutine(battleCoroutine); // Ensure no duplicate coroutine runs

        battleCoroutine = StartCoroutine(HandleBattle());
    }

    IEnumerator HandleBattle() {
        Character actor = player, target = enemy;
        while (true) {
            HandleBattle(actor, target);
            if (IsBattleEnded()) {
                EndBattle();
                break;
            }
            System.Action swap = () =>
            {
                (actor, target) = (target, actor);
            };
            swap();
            yield return null;
        }
    }
    void HandleBattle(Character actor, Character target) {
        for (int i = 0; i < actor.GetSkillCount(); i++) {
            actor.ProgressSkill();
            if (actor.IsSkillReady(i)) {
                SkillManager.Instance.ActivateSkill(actor.characterData.skillIds[i], actor, target);
                actor.EnterCooldown(i);
            }
        }
        EffectManager.Instance.HandleInstantEffect(target);
    }

    bool IsBattleEnded() {
        return player.Health < 0 || enemy.Health < 0;
    }

    void EndBattle() {

    }
    public void EndPhase() {
        battleUI.SetActive(false);
    }
}
