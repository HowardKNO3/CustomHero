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
    Reward chosenReward;
    public RewardUIDisplayer rewardUIDisplayer;
    public GameObject rewardUI;
    public Character player;
    public void StartReward() {
        rewards = new Reward[MAX_REWARD_COUNT];
        rewardUI.SetActive(true);
        GenerateReward();
        rewardUIDisplayer.DisplayAllRewards(rewards);
    }
    void GenerateReward() {
        for (int i = 0; i < MAX_REWARD_COUNT; i++) {
            Reward reward = new Reward();
            int rewardType = Random.Range(0, MAX_REWARD_TYPES);
            reward.rewardType = rewardType;
            switch (rewardType) {
                case SKILL_REWARD:
                    reward.rewardValue = Random.Range(1, SkillManager.Instance.GetSkillCount());
                    break;
                case POWERUP_REWARD:
                    reward.rewardValue = Random.Range(0, ATTRIBUTE_TYPES);
                    break;
                case HEAL_REWARD:
                    reward.rewardValue = HEAL_REWARD_CHOOSE[Random.Range(0, HEAL_REWARD_CHOOSE.Length)];
                    break;
            }
            if (DuplicateRewardCheck(i, reward)) i--;
            else rewards[i] = reward;
        }
    }
    bool DuplicateRewardCheck(int index, Reward checkReward) {
        if (checkReward.rewardType == HEAL_REWARD) {
            for (int i = 0; i < index; i++) {
                if (checkReward.rewardType == rewards[i].rewardType) return true;
            }
        } else if (checkReward.rewardType == POWERUP_REWARD) {
            for (int i = 0; i < index; i++) {
                if (checkReward.rewardType == rewards[i].rewardType
                && checkReward.rewardValue == rewards[i].rewardValue) return true;
            }
        } else {
            if (player.IsLearned(checkReward.rewardValue)) return true;
            for (int i = 0; i < index; i++) {
                if (checkReward.rewardType == rewards[i].rewardType
                && checkReward.rewardValue == rewards[i].rewardValue) return true;
            }
        }
        return false;
    }
    public void GetReward(int rewardIndex)
    {
        StartCoroutine(HandleReward(rewardIndex));
    }
    IEnumerator HandleReward(int rewardIndex) {
        chosenReward = rewards[rewardIndex];
        switch (chosenReward.rewardType) {
            case SKILL_REWARD:
                if (player.GetSkillCount() < MAX_SKILL_COUNT) player.LearnSkill(chosenReward.rewardValue, player.GetSkillCount());
                else {
                    rewardUIDisplayer.DisplayAllSkillChooses(player.characterData.skillIds);
                    yield return new WaitUntil(() => rewardUIDisplayer.HasPlayerMadeSelection);
                    int selectedSkillIndex = rewardUIDisplayer.GetSelectedSkillIndex();
                    player.LearnSkill(chosenReward.rewardValue, selectedSkillIndex);
                }
                break;
            case POWERUP_REWARD:
                int[] powerups = new int[ATTRIBUTE_TYPES];
                powerups[chosenReward.rewardValue] = 1;
                player.GetPowerup(powerups);
                break;
            case HEAL_REWARD:
                player.Heal(player.characterData.maxHealth * (chosenReward.rewardValue / 100));
                break;
        }
        player.PrintCharacterInfo();
    }
    
}
