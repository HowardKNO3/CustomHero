using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    public GameObject InfoUI;
    public InfoPanel infoPanel;
    public void ShowInfo() {
        InfoUI.SetActive(true);
        infoPanel.UpdateInfo();
    }
    public void HideInfo() {
        InfoUI.SetActive(false);
    }
}
