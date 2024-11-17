using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUIDisplayer : MonoBehaviour
{
    public SkillBar[] skillBars;
    public HealthBar playerHealthBar;
    public Character player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSkillUI();
        UpdateHealthUI();
    }

    void UpdateSkillUI() {
        int skillCount = player.GetSkillCount();
        for (int i = 0; i < skillCount; i++) {
            skillBars[i].UpdateSkillBar(player.SkillFills[i]);
        }
    }
    void UpdateHealthUI() {
        playerHealthBar.UpdateHealthBar(player.Health / player.characterData.maxHealth);
    }
}
