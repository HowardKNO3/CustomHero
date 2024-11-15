using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static Constants;
using Random = UnityEngine.Random;

public class Reward {
    public int rewardType;
    public int rewardValue;

}

public class RewardManager : MonoBehaviour
{

    Reward[] rewards = new Reward[MAX_REWARD_COUNT];
    public RewardUIDisplayer rewardUIDisplayer;
    public GameObject rewardUI;
    public void StartReward() {
        rewards = new Reward[MAX_REWARD_COUNT];
        rewardUI.SetActive(true);
        GenerateReward();
        rewardUIDisplayer.DisplayAllRewards(rewards);
    }
    void GenerateReward() {
        for (int i = 0; i < MAX_REWARD_COUNT; i++) {
            rewards[i] = new Reward();
            int rewardType = Random.Range(0, MAX_REWARD_TYPES);
            rewards[i].rewardType = rewardType;
            switch (rewardType) {
                case SKILL_REWARD:
                    rewards[i].rewardValue = 1;
                    break;
                case POWERUP_REWARD:
                    rewards[i].rewardValue = Random.Range(0, ATTRIBUTE_TYPES);
                    break;
                case HEAL_REWARD:
                    rewards[i].rewardValue = HEAL_REWARD_CHOOSE[Random.Range(0, HEAL_REWARD_CHOOSE.Length)];
                    break;
            }

        }
    }
}
