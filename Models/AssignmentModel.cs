using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mis_mmc.Models;

public class AssignmentModel
{
    [Key]
    public int s_no { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public DateOnly published_date { get; set; }
    public string file { get; set; }
    public int points { get; set; }
    public  DateOnly due_date { get; set; }
    public List<AssignmentReturnModel> AssignmentReturnModels { get; set; } 

    
    [ForeignKey("cid")]
    public virtual CourseModel CourseModel { get; set; }  
    public int cid { get; set; }
    [ForeignKey("tid")]
    public virtual TeacherModel TeacherModel { get; set; }  
    public int tid { get; set; }
    
}