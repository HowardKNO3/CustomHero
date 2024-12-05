using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;
using System;

public class ResultManager : PhaseManager
{
    public Character player;
    public GameObject resultUI;
    public ResultUIDisplayer resultUIDisplayer;
    public void StartPhase() {
        player.CalculateExperience();
        resultUI.SetActive(true);
        resultUIDisplayer.HideButton();
        resultUIDisplayer.DisplayResult();
        StartCoroutine(HandleExperience());
    }
    public void EndPhase() {
        resultUI.SetActive(false);
    }
    public void EndResult() {
        GameManager.Instance.ChangeGamePhase();
    }
    
    IEnumerator HandleExperience() {
        
        bool isFinished() {
            for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
                if (player.gainExperienceAmount[i] > 0) return false;
            }
            return true;
        }
        yield return new WaitForSeconds(0.5f);
        double gainSpeed = 1000;
        while (true) {
            for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
                player.GainExperience(gainSpeed * Time.deltaTime, i);
            }
            gainSpeed *= 1.001f;
            yield return null;
            resultUIDisplayer.DisplayResult();
            if (isFinished()) {
                for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
                    player.AttributeExperiences[i] = Math.Round(player.AttributeExperiences[i]);
                    resultUIDisplayer.DisplayResult();
                }
                break;
            }
        }
        resultUIDisplayer.ShowButton();
    }
}
