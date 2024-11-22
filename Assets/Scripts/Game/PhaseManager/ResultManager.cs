using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class ResultManager : MonoBehaviour, PhaseManager
{
    public Character player;
    public GameObject resultUI;
    public ResultUIDisplayer resultUIDisplayer;
    
    public void StartPhase() {
        player.CalculateExperience();
        resultUI.SetActive(true);
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
        float baseGetSpeed = 0.1f;
        float[] experienceAccumulators = new float[MAX_ATTRIBUTE_TYPES];
        while (true) {
            
            for (int i = 0; i < MAX_ATTRIBUTE_TYPES; i++) {
                experienceAccumulators[i] += baseGetSpeed * Time.deltaTime;
                if (experienceAccumulators[i] >= 1f) {
                    int gain = (int)experienceAccumulators[i];
                    player.GetExperience(gain, i);
                    experienceAccumulators[i] -= gain;
                }
                player.GetExperience(baseGetSpeed, i);
            }
            baseGetSpeed += 0.0001f;
            yield return null;
            resultUIDisplayer.DisplayResult();
            if (isFinished()) break;
        }
    }
}
