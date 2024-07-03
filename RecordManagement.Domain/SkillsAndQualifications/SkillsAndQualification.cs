using RecordManagement.Domain.Common.Models;
using RecordManagement.Domain.SkillsAndQualifications.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace RecordManagement.Domain.SkillsAndQualifications;
public class SkillsAndQualification : Entity<SkillId>
{
  
    public string Skill { get; }
    public string Language { get; }

    private SkillsAndQualification(
        string skill,
        string language
       ) : base (SkillId.CreateUnique())

    {
        Skill = skill;
        Language = language;
    }
    
    public static SkillsAndQualification Create(
        string skill,
        string language) 
    {
        return new SkillsAndQualification(
            skill, 
            language
          );
    }



#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private SkillsAndQualification() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
