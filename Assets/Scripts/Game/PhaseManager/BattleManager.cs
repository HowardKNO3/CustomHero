using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour, PhaseManager
{
    
    public GameObject battleUI;
    // Start is called before the first frame update
    public void StartPhase() {
        battleUI.SetActive(true);
    }
    public void EndPhase() {
        battleUI.SetActive(false);
    }
}
