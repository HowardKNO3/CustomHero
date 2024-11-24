using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class ExperienceBars : MonoBehaviour
{
    public ExperienceBar[] experienceBars;
    public void UpdateUI(Character character) {
        for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
            
            experienceBars[i].UpdateBar(character);
        }
    }
}
