using TMPro;
using UnityEngine;
using static Constants;

public class ActionUIDisplayer : MonoBehaviour {
    public Character player;
    public HealthBar playerHealthBar;
    public GameObject playerInfo;
    public TextMeshProUGUI remainingRoundText;
    void Start() {
        playerInfo.SetActive(false);
    }
    void Update() {
        playerHealthBar.UpdateBar(player);
        remainingRoundText.text = GameManager.Instance.RemainingRound.ToString();
    }
}