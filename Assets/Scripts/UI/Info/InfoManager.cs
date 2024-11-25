using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    public GameObject infoUI;
    public InfoPanel infoPanel;
    public void ShowInfo() {
        infoUI.SetActive(true);
        infoPanel.UpdateInfo();
    }
    public void HideInfo() {
        infoUI.SetActive(false);
    }
}
