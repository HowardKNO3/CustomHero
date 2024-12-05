using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class BattleManager : PhaseManager
{
    public bool isBossFight;
    public GameObject battleUI;
    public Character player;
    public Character enemy;
    double battleTime;
    public double BattleTime {
        get {return battleTime;} 
        private set {}
    }
    
    Coroutine battleCoroutine;
    public static BattleManager Instance {private set; get;}
    void Awake() {
        if (Instance != null && Instance != this) {
            Debug.LogWarning("PhaseManager: " +
            "Duplicate instance detected and removed. Only one instance of PhaseManager is allowed.");
            Destroy(Instance);
            return;
        }
        Instance = this;
    }
    public void StartPhase() {
        isBossFight = GameManager.Instance.GamePhase == GAMEPHASE.BOSS_BATTLE;
        battleUI.SetActive(true);
        if (battleCoroutine != null)
            StopCoroutine(battleCoroutine);
        PrepareBattle();
        battleCoroutine = StartCoroutine(HandleBattle());
    }
    void PrepareBattle() {
        player.BattleReset(false);
        enemy.BattleReset(true);
        
        battleTime = 0;
        foreach (var Skill in player.Skills) {
            if (Skill is PassiveSkill) Skill.Activate(player, enemy);
        }
        foreach (var Skill in enemy.Skills) {
            if (Skill is PassiveSkill) Skill.Activate(enemy, player);
        }
    }

    IEnumerator HandleBattle() {
        while (true) {
            battleTime += Time.deltaTime;
            EffectManager.Instance.HandlePassiveEffect<TimeBasedAdjustment>(player, enemy);
            HandleBattleAction(player, enemy);
            EffectManager.Instance.HandlePassiveEffect<TimeBasedAdjustment>(enemy, player);
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
                actor.SkillUsageCounts[i]++;
                SkillManager.Instance.ActivateSkill(actor.Skills[i], actor, target);
                EffectManager.Instance.HandlePassiveEffect<UsageCountAdjustment>(actor, target);
                actor.EnterCooldown(i);
            }
        }
        EffectManager.Instance.HandleHealthEffect(target);
        EffectManager.Instance.HandleAccelerateEffect(target);
        EffectManager.Instance.HandlePassiveEffect<HealthBasedAdjustment>(actor, target);
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
