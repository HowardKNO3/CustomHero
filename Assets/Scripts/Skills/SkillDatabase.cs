using UnityEngine;

[CreateAssetMenu(fileName = "SkillDatabase", menuName = "Skills/SkillDatabase")]
public class SkillDatabase : ScriptableObject
{
    [SerializeField] public Skill[] skills;

    public Skill GetSkillById(int id)
    {
        return System.Array.Find(skills, skill => skill.id == id);
    }
}
