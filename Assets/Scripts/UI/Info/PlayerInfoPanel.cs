using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInfoPanel : InfoPanel
{
    public ExperienceBars experienceBars;
    public SkillPanels skillPanels;
    public Character character;
    public override void UpdateInfo() {
        experienceBars.UpdateUI(character);
        skillPanels.UpdateUI(character);
    }
    
}
