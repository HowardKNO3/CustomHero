using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static Constants;

public class RewardUIDisplayer : MonoBehaviour
{
    public GameObject rewardPanelList;
    public GameObject skillChoosePanelList;
    public RewardPanel[] rewardPanels;
    public SkillChoosePanel[] skillChoosePanels;
    int selectedSkillIndex;
    bool hasPlayerMadeSelection = false;
    public bool HasPlayerMadeSelection => hasPlayerMadeSelection;
    public void DisplayAllRewards(Reward[] rewards) {
        rewardPanelList.SetActive(true);
        skillChoosePanelList.SetActive(false);
        for (int i = 0; i < MAX_REWARD_COUNT; i++) {
            rewardPanels[i].DisplayReward(rewards[i]);
        }
    }

    public void DisplayAllSkillChooses(int[] skillIds) {
        rewardPanelList.SetActive(false);
        skillChoosePanelList.SetActive(true);
        for (int i = 0; i < MAX_SKILL_COUNT; i++) {
            skillChoosePanels[i].DisplaySkill(skillIds[i]);
        }
    }

    public void OnSkillSelected(int skillIndex)
    {
        selectedSkillIndex = skillIndex;
        hasPlayerMadeSelection = true;
    }

    public int GetSelectedSkillIndex() {
        return selectedSkillIndex;
    }
}
