using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;



public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance { get; private set; }
    public ActionManager actionManager;
    public RewardManager rewardManager;
    public BattleManager battleManager;
    public ResultManager resultManager;
    GAMEPHASE gamePhase;
    public Character player;
    public Character normalEnemy, bossEnemy;
    CharacterData normalEnemyData, bossEnemyData;
    int remainingRound;
    public Level[] levelList;
    int currentLevelIndex;
    public int RemainingRound {
        get {return remainingRound;}
    }
    
    public Level CurrentLevel {
        get {return GetCurrentLevel();}
    }

    public GAMEPHASE GamePhase {
        get {return gamePhase;}
    }
    void Awake() {
        remainingRound = INIT_ROUND;
        currentLevelIndex = 0;
        if (Instance != null && Instance != this) {
            Debug.LogWarning("GameManager: " +
            "Duplicate instance detected and removed. Only one instance of GameManager is allowed.");
            Destroy(Instance);
            return;
        }
        Instance = this;
        gamePhase = GAMEPHASE.ACTION;
        RefreshEnemyData();
    }

    


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ChangeGamePhase();
        }
    }

    public void ChangeGamePhase() {
        TooltipManager.Instance.HideTip();
        switch (gamePhase) {
            case GAMEPHASE.ACTION: 
                if (actionManager.lastAction == ACTION.START_NORMAL_BATTLE) {
                    gamePhase = GAMEPHASE.NORMAL_BATTLE;
                    battleManager.enemy = normalEnemy;
                }
                else {
                    gamePhase = GAMEPHASE.BOSS_BATTLE;
                    battleManager.enemy = bossEnemy;
                }
                actionManager.EndPhase();
                battleManager.StartPhase();
                break;
            case GAMEPHASE.NORMAL_BATTLE:
            case GAMEPHASE.BOSS_BATTLE: 
                battleManager.EndPhase();
                resultManager.StartPhase();
                gamePhase = GAMEPHASE.RESULT;
                break;
            case GAMEPHASE.RESULT: 
                resultManager.EndPhase();
                if (player.IsVictory) {
                    rewardManager.StartPhase();
                    gamePhase = GAMEPHASE.REWARD;
                    remainingRound -= 1;
                }
                else {
                    actionManager.StartPhase();
                    gamePhase = GAMEPHASE.ACTION;
                    remainingRound -= 3;
                    player.Health = player.MaxHealth;
                }
                break;
            case GAMEPHASE.REWARD: 
                rewardManager.EndPhase();
                actionManager.StartPhase();
                gamePhase = GAMEPHASE.ACTION;
                RefreshEnemyData();
                break;
        }
        print(gamePhase);
    }
    public Level GetCurrentLevel() {
        return levelList[currentLevelIndex];
    }
    void RefreshEnemyData()
    {
        normalEnemyData = CurrentLevel.GenerateEnemyData(false);
        normalEnemy.characterData = normalEnemyData;
        bossEnemyData = CurrentLevel.GenerateEnemyData(true);
        bossEnemy.characterData = bossEnemyData;
    }
}
