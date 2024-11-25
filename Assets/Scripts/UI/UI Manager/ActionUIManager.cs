using UnityEngine;
using static Constants;

public class ActionUIDisplayer : MonoBehaviour {
    public Character player;
    public HealthBar playerHealthBar;
    public GameObject playerInfo;
    void Start() {
        playerInfo.SetActive(false);
    }
    void Update() {
        playerHealthBar.UpdateBar(player);
    }
}