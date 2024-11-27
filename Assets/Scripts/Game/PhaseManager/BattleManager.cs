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
            StopCoroutine(battleCoroutine);
        PrepareBattle();
        battleCoroutine = StartCoroutine(HandleBattle());
        
    }
    void PrepareBattle() {
        player.BattleReset(false);
        enemy.BattleReset(true);
    }

    IEnumerator HandleBattle() {
        while (true) {
            HandleBattleAction(player, enemy);
            HandleBattleAction(enemy, player);
            if (IsBattleEnded()) {
                EndBattle();
                break;
            }            
            yield return null;
        }
    }
    void HandleBattleAction(Character actor, Character target) {
        actor.ProgressSkill();
        for (int i = 0; i < actor.GetSkillCount(); i++) {
            if (actor.IsSkillReady(i)) {
                SkillManager.Instance.ActivateSkill(actor.SkillIds[i], actor, target);
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
        GameManager.Instance.ChangeGamePhase();
    }
    public void EndPhase() {
        battleUI.SetActive(false);
    }
}
