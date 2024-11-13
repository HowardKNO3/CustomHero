using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Skills/Skill")]
public class Skill : ScriptableObject
{
    public int id;
    public string skillName;
    public float cooldown;
    public string description;

    // Optional: A method to trigger skill effects
    public virtual void Activate(Character user, Character target)
    {
        // Implement skill activation logic, e.g., apply effects to the user or target
    }
}

