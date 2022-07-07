using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mis_mmc.Models;

public class AssignmentReturnModel
{
    [Key]
    public int s_no { get; set; }
   
    public string file { get; set; }
    public DateOnly return_date { get; set; }
    public bool is_checked{ get; set; }
    public int? points { get; set; }

    [ForeignKey("cid")]
    public virtual CourseModel CourseModel { get; set; }
    public int cid { get; set; }
    [ForeignKey("tid")]
    public virtual TeacherModel TeacherModel { get; set; }
    public int tid { get; set; }
    [ForeignKey("sid")]
    public virtual StudentModel StudentModel { get; set; }
    public int sid { get; set; }
    [ForeignKey("aid")]
    public virtual AssignmentModel AssignmentModel { get; set; }
    public int aid { get; set; }
}