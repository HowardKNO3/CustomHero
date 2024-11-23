using UnityEngine;
using UnityEngine.UI;

public class SkillBar : MonoBehaviour
{
    public Slider skillSlider; // Assign the slider in the inspector

    void Start()
    {
        // Initialize the skill bar and slider based on the slider's starting value
        UpdateSkillBar(skillSlider.value);
    }

    // Method to update both the skill bar's fill amount and the slider's value
    public void UpdateSkillBar(double skillPercentage)
    {
        skillSlider.value = Mathf.Clamp01((float)skillPercentage); // Update the slider's value
    }
}
