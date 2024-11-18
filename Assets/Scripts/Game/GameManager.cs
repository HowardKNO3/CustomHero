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
    GAMEPHASE gamePhase;

    void Awake() {
        if (Instance != null && Instance != this) {
            Debug.LogWarning("GameManager: " +
            "Duplicate instance detected and removed. Only one instance of GameManager is allowed.");
            Destroy(Instance);
            return;
        }
        Instance = this;
        gamePhase = GAMEPHASE.ACTION;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ChangeGamePhase();
        }
    }

    public void ChangeGamePhase() {
        
        if (gamePhase == GAMEPHASE.ACTION) {
            actionManager.EndPhase();
            battleManager.StartPhase();
            gamePhase = GAMEPHASE.BATTLE;
        }
        else if (gamePhase == GAMEPHASE.BATTLE) {
            battleManager.EndPhase();
            rewardManager.StartPhase();
            gamePhase = GAMEPHASE.REWARD;
        }
        else {
            rewardManager.EndPhase();
            actionManager.StartPhase();
            gamePhase = GAMEPHASE.ACTION;
        }
        print(gamePhase);
    }
}
