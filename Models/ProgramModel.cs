using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mis_mmc.Models;

public class ProgramModel
{
    
    [Key] 
    public int s_no { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string? file { get; set; }
    
    public string type { get; set; }
    public string system { get; set; }
    public string? director { get; set; }
    public int sem_year { get; set; }
    [ForeignKey("fid")]
    public FacultyModel faculty { get; set; }  
    public int fid { get; set; }
}