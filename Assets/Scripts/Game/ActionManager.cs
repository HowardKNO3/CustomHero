using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class ActionManager : MonoBehaviour, PhaseManager
{
    public GameObject actionUI;
    public void StartPhase() {
        actionUI.SetActive(true);
    }

    public void EndPhase() {
        actionUI.SetActive(false);
    }

    public void DoActionOnClick(int actionIndex) {
        switch (actionIndex) {
            case 0: 
                DoAction(ACTION.NORMAL_BATTLE);
                break;
            case 1: 
                DoAction(ACTION.BOSS_BATTLE);
                break;
            case 2: 
                DoAction(ACTION.REST);
                break;
        }
    }
    public void DoAction(ACTION action) {
        if (action == ACTION.NORMAL_BATTLE || action == ACTION.BOSS_BATTLE) {
            GameManager.Instance.ChangeGamePhase();
        }
    }
}
