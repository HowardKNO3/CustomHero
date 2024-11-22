using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour, PhaseManager
{
    public GameObject resultUI;
    public ResultUIDisplayer resultUIDisplayer;
    
    public void StartPhase() {
        resultUI.SetActive(true);
        resultUIDisplayer.DisplayResult();
    }
    public void EndPhase() {
        resultUI.SetActive(false);
    }
    public void EndResult() {
        GameManager.Instance.ChangeGamePhase();
    }
}
