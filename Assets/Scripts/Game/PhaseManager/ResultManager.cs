using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;
using System;

public class ResultManager : MonoBehaviour, PhaseManager
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
                if (player.getExperienceAmount[i] > 0) return false;
            }
            return true;
        }
        yield return new WaitForSeconds(0.5f);
        double getSpeed = 3f;
        double[] experienceAccumulators = new double[MAX_ATTRIBUTE_TYPES];
        while (true) {
            for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
                player.GetExperience(getSpeed, i);
            }
            getSpeed *= 1.001f;
            yield return null;
            resultUIDisplayer.DisplayResult();
            if (isFinished()) {
                for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
                    player.characterData.attributeExperiences[i] = Math.Round(player.characterData.attributeExperiences[i]);
                    resultUIDisplayer.DisplayResult();
                }
                break;
            }
        }
        resultUIDisplayer.ShowButton();
    }
}
