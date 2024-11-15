using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    
    public GameObject battleUI;
    // Start is called before the first frame update
    public void EndBattle() {
        battleUI.SetActive(false);
    }
}
