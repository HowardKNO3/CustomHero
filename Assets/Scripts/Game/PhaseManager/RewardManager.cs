using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static Constants;
using Random = UnityEngine.Random;

public class Reward {
    public REWARD_TYPE rewardType;
    public int rewardValue;

}

public class RewardManager : MonoBehaviour, PhaseManager
{

    Reward[] rewards = new Reward[MAX_REWARD_COUNT];
    Reward chosenReward;
    public RewardUIDisplayer rewardUIDisplayer;
    public GameObject rewardUI;
    public Character player;
    public void StartPhase() {
        rewards = new Reward[MAX_REWARD_COUNT];
        rewardUI.SetActive(true);
        rewardUIDisplayer.DisplayBattleResult();

        GenerateReward();
        rewardUIDisplayer.DisplayAllRewards(rewards);
    }
    public void EndPhase() {
        rewardUI.SetActive(false);
    }
    void GenerateReward() {
        for (int i = 0; i < MAX_REWARD_COUNT; i++) {
            Reward reward = new Reward();
            REWARD_TYPE rewardType = (REWARD_TYPE)Random.Range(0, MAX_REWARD_TYPES);
            reward.rewardType = rewardType;
            switch (rewardType) {
                case REWARD_TYPE.SKILL_REWARD:
                    reward.rewardValue = Random.Range(1, SkillManager.Instance.GetSkillCount());
                    break;
                case REWARD_TYPE.POWERUP_REWARD:
                    reward.rewardValue = Random.Range(0, MAX_ATTRIBUTE_TYPES);
                    break;
                case REWARD_TYPE.HEAL_REWARD:
                    reward.rewardValue = HEAL_REWARD_CHOOSE[Random.Range(0, HEAL_REWARD_CHOOSE.Length)];
                    break;
            }
            if (DuplicateRewardCheck(i, reward)) i--;
            else rewards[i] = reward;
        }
    }
    bool DuplicateRewardCheck(int index, Reward checkReward) {
        if (checkReward.rewardType == REWARD_TYPE.HEAL_REWARD) {
            for (int i = 0; i < index; i++) {
                if (checkReward.rewardType == rewards[i].rewardType) return true;
            }
        } else if (checkReward.rewardType == REWARD_TYPE.POWERUP_REWARD) {
            for (int i = 0; i < index; i++) {
                if (checkReward.rewardType == rewards[i].rewardType
                && checkReward.rewardValue == rewards[i].rewardValue) return true;
            }
        } else {
            Skill rewardSkill = SkillManager.Instance.GetSkillByIndex(checkReward.rewardValue);
            if (player.IsLearned(rewardSkill)) return true;
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
            case REWARD_TYPE.SKILL_REWARD:
                Skill rewardSkill = SkillManager.Instance.GetSkillByIndex(chosenReward.rewardValue);
                if (player.GetSkillCount() < MAX_SKILL_COUNT) player.LearnSkill(rewardSkill, player.GetSkillCount());
                else {
                    rewardUIDisplayer.DisplayAllSkillChooses(player.Skills);
                    yield return new WaitUntil(() => rewardUIDisplayer.HasPlayerMadeSelection);
                    int selectedSkillIndex = rewardUIDisplayer.GetSelectedSkillIndex();
                    player.LearnSkill(rewardSkill, selectedSkillIndex);
                }
                break;
            case REWARD_TYPE.POWERUP_REWARD:
                int[] powerups = new int[MAX_ATTRIBUTE_TYPES];
                powerups[chosenReward.rewardValue] = 1;
                player.GetPowerup(powerups);
                break;
            case REWARD_TYPE.HEAL_REWARD:
                player.Heal(player.MaxHealth * chosenReward.rewardValue / 100);
                break;
        }
        player.PrintCharacterInfo();
        GameManager.Instance.ChangeGamePhase();
    }
    
}
