using System.Linq.Expressions;
using UnityEngine;

public static class Constants
{
    public const int MAX_SKILL_COUNT = 4;
    public const int MAX_REWARD_COUNT = 3;
    public const int MAX_REWARD_TYPES = 3;
    public const int ATTRIBUTE_TYPES = 3;
    public const float BASIC_SKILL_SPEED = 50;

    public const int SKILL_REWARD = 0;
    public const int POWERUP_REWARD = 1;
    public const int HEAL_REWARD = 2;
    
    public static readonly int[] HEAL_REWARD_CHOOSE = {50, 75, 100};
    public static readonly string[] ATTRIBUTE_NAME = {"力量", "敏捷", "智力"};

    public enum ACTION {
        NORMAL_BATTLE,
        BOSS_BATTLE,
        REST
    }

    public enum GAMEPHASE {
    ACTION,
    BATTLE,
    REWARD
}
}
