using System.Linq.Expressions;
using UnityEngine;

public static class Constants
{
    public const int MAX_SKILL_COUNT = 4;
    public const int MAX_REWARD_COUNT = 3;
    public const int MAX_REWARD_TYPES = 3;
    public const int MAX_ATTRIBUTE_TYPES = 3;
    public const int INIT_ROUND = 40;

    public const double BASE_PLAYER_CHARACTER_HEALTH = 5000;
    public const double BASE_ENEMY_CHARACTER_HEALTH = 3000;

    public const double BASE_HEALTH_EFFECT_AMOUNT = 100;
    public const double BASE_SKILL_SPEED = 75;
    public const double BASE_EXP_REQUIREMENT = 2000;

    public const double LIN_FACTOR_EXP = 0.1;
    public const double EXP_FACTOR_EXP = 1.07;

    public const double LIN_FACTOR_EFFECT = 0.06;
    public const double EXP_FACTOR_EFFECT = 1.04;
    
    public static readonly int[] HEAL_REWARD_CHOOSE = {50, 75, 100};
    public static readonly string[] ATTRIBUTE_NAME = {"力量", "敏捷", "智力"};


    public enum REWARD_TYPE {
        SKILL_REWARD,
        POWERUP_REWARD,
        HEAL_REWARD,
    }
    public enum ACTION {
        START_NORMAL_BATTLE,
        START_BOSS_BATTLE,
        REST
    }

    public enum GAMEPHASE {
        ACTION,
        NORMAL_BATTLE,
        BOSS_BATTLE,
        RESULT,
        REWARD
    }
}
