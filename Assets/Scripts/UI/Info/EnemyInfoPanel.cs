using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class EnemyInfoPanel : InfoPanel
{
    public Character character;
    public TextMeshProUGUI enemyMainInfoText;
    public SkillPanels skillPanels;
    public override void UpdateInfo() {
        enemyMainInfoText.text = "總兵力 " + character.MaxHealth;
        skillPanels.UpdateUI(character);

    }
    
}
