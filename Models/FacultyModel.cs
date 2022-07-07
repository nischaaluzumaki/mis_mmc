using System.ComponentModel.DataAnnotations;
namespace mis_mmc.Models;


public class FacultyModel
{
    [Key] 
    public int s_no { get; set; }
    public string uid { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string? file { get; set; }
    public string? hod { get; set; }

    public virtual ICollection<ProgramModel> ProgramModels { get; set; }

}