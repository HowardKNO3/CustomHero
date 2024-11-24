using System.Linq.Expressions;
using UnityEngine;

public static class Constants
{
    public const int MAX_SKILL_COUNT = 4;
    public const int MAX_REWARD_COUNT = 3;
    public const int MAX_REWARD_TYPES = 3;
    public const int MAX_ATTRIBUTE_TYPES = 3;

    public const double BASE_SKILL_SPEED = 50;
    public const double BASE_UPGRADE_EXPERIENCE = 2000;
    
    public static readonly int[] HEAL_REWARD_CHOOSE = {50, 75, 100};
    public static readonly string[] ATTRIBUTE_NAME = {"力量", "敏捷", "智力"};


    public enum REWARD_TYPE {
        SKILL_REWARD,
        POWERUP_REWARD,
        HEAL_REWARD,
    }
    public enum ACTION {
        NORMAL_BATTLE,
        BOSS_BATTLE,
        REST
    }

    public enum GAMEPHASE {
        ACTION,
        BATTLE,
        RESULT,
        REWARD
    }
}
