using UnityEngine;

[CreateAssetMenu(fileName = "SkillDatabase", menuName = "Skills/SkillDatabase")]
public class SkillDatabase : ScriptableObject
{
    [SerializeField] public Skill[] skills;

    public Skill GetSkillByIndex(int index)
    {
        return skills[index];
    }
}
