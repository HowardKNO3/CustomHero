using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class ActionManager : PhaseManager
{
    public GameObject actionUI;
    [HideInInspector] public ACTION lastAction;
    public void StartPhase() {
        actionUI.SetActive(true);
    }

    public void EndPhase() {
        actionUI.SetActive(false);
    }

    public void DoActionOnClick(int actionIndex) {
        switch (actionIndex) {
            case 0: 
                DoAction(ACTION.START_NORMAL_BATTLE);
                break;
            case 1: 
                DoAction(ACTION.START_BOSS_BATTLE);
                break;
            case 2: 
                DoAction(ACTION.REST);
                break;
        }
    }
    public void DoAction(ACTION action) {
        lastAction = action;
        if (action == ACTION.START_NORMAL_BATTLE || action == ACTION.START_BOSS_BATTLE) {
            GameManager.Instance.ChangeGamePhase();
        }
    }
}
