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
        switch (gamePhase) {
            case GAMEPHASE.ACTION: 
                actionManager.EndPhase();
                battleManager.StartPhase();
                gamePhase = GAMEPHASE.BATTLE;
                break;
            case GAMEPHASE.BATTLE: 
                battleManager.EndPhase();
                resultManager.StartPhase();
                gamePhase = GAMEPHASE.RESULT;
                break;
            case GAMEPHASE.RESULT: 
                resultManager.EndPhase();
                rewardManager.StartPhase();
                gamePhase = GAMEPHASE.REWARD;
                break;
            case GAMEPHASE.REWARD: 
                rewardManager.EndPhase();
                actionManager.StartPhase();
                gamePhase = GAMEPHASE.ACTION;
                break;
        }
        print(gamePhase);
    }
}
