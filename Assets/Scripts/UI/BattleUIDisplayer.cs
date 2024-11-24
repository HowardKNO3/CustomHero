using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class BattleUIDisplayer : MonoBehaviour
{
    
    public Character player;
    public Character enemy;
    public SkillBars playerSkillBars;
    public SkillBars enemySkillBars;
    public HealthBar playerHealthBar;
    public HealthBar enemyHealthBar;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkillBars();
        UpdateHealthBars();
    }

    void UpdateSkillBars() {
        playerSkillBars.UpdateUI(player);
        enemySkillBars.UpdateUI(enemy);
    }
    void UpdateHealthBars() {
        playerHealthBar.UpdateBar(player);
        enemyHealthBar.UpdateBar(enemy);
    }
}
