using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class RewardUIDisplayer : MonoBehaviour
{
    public RewardPanel[] rewardPanels;
    public void DisplayAllRewards(Reward[] rewards) {
        for (int i = 0; i < MAX_REWARD_COUNT; i++) {
            rewardPanels[i].DisplayReward(rewards[i]);
        }
    }
}
