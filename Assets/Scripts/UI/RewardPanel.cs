using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Constants;

public class RewardPanel : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    void Start() {
    }

    public void DisplayReward(Reward reward) {
        switch (reward.rewardType) {
            case SKILL_REWARD:
                Skill rewardSkill = SkillManager.Instance.GetSkillById(reward.rewardValue);
                titleText.text = "獲得技能:" + rewardSkill.skillName;
                descriptionText.text = rewardSkill.description;
                break;
            case POWERUP_REWARD:
                titleText.text = "獲得強化:" + ATTRIBUTE_NAME[reward.rewardValue];
                descriptionText.text = "獲得 1 次" + ATTRIBUTE_NAME[reward.rewardValue] + "強化";
                break;
            case HEAL_REWARD:
                titleText.text = "回復生命";
                descriptionText.text = "回復 " + reward.rewardValue + " % 生命值";
                break;
        }
    }
}
