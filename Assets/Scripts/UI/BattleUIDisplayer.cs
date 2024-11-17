using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

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
        for (int i = 0; i < MAX_SKILL_COUNT; i++) {
            if (player.characterData.skillIds[i] != 0) skillBars[i].UpdateSkillBar(player.SkillFills[i]);
            else {
                skillBars[i].gameObject.SetActive(false);
            }
        }
    }
    void UpdateHealthUI() {
        playerHealthBar.UpdateHealthBar(player.Health / player.characterData.maxHealth);
    }
}
