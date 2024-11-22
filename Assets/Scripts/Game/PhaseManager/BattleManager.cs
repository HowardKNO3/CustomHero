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
        while (true) {
            HandleBattle(player, enemy);
            HandleBattle(enemy, player);
            if (IsBattleEnded()) {
                EndBattle();
                break;
            }            
            yield return new WaitForSeconds(UPDATE_RATE);
        }
    }
    void HandleBattle(Character actor, Character target) {
        actor.ProgressSkill();
        for (int i = 0; i < actor.GetSkillCount(); i++) {
            if (actor.IsSkillReady(i)) {
                SkillManager.Instance.ActivateSkill(actor.characterData.skillIds[i], actor, target);
                actor.EnterCooldown(i);
            }
        }
        EffectManager.Instance.HandleHealthEffect(target);
        EffectManager.Instance.UpdateEffectTimer(actor);
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
