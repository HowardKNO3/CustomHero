using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Constants;

public class ResultUIDisplayer : MonoBehaviour
{
    public Character player;
    public TextMeshProUGUI[] damageText;
    public TextMeshProUGUI[] healText;
    public ExperienceBars experienceBars;
    public GameObject continueButton;
    public void DisplayResult() {
        experienceBars.UpdateUI(player);
        for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
            damageText[i].text = ((int)player.battleResult.totalDamageAmount[i]).ToString();
            healText[i].text = ((int)player.battleResult.totalHealAmount[i]).ToString();
        }
    }
    public void ShowButton() {
        continueButton.SetActive(true);
    }
    public void HideButton() {
        continueButton.SetActive(false);
    }
}
