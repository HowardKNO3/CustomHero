using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class SkillBars : MonoBehaviour
{
    public SkillBar[] skillBars;
    public void UpdateUI(Character character) {
        for (int i = 0; i < MAX_SKILL_COUNT; i++) {
            if (character.characterData.skillIds[i] != 0) skillBars[i].UpdateBar(character);
            else {
                skillBars[i].gameObject.SetActive(false);
            }
        }
    }
}
