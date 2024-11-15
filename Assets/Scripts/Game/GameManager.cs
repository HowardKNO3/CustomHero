using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public RewardManager rewardManager;
    public BattleManager battleManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            battleManager.EndBattle();
            rewardManager.StartReward();
        }
    }
}
