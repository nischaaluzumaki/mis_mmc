using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mis_mmc.Models;

public class CourseModel
{
    [Key]
    public int s_no { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string? file { get; set; }
    
    public string sem_year { get; set; }
    
    public string? lecturer { get; set; }
    [ForeignKey("pid")]
    public virtual ProgramModel ProgramModel { get; set; }  
    public int pid { get; set; }
    
}