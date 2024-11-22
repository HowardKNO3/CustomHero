using UnityEngine;
using static Constants;

public class ActionUIDisplayer : MonoBehaviour {
    public Character player;
    public HealthBar playerHealthBar;
    void Update() {
        playerHealthBar.UpdateHealthBar(player);
    }
}