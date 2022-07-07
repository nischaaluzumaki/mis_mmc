using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mis_mmc.Models;

public class ExamDetailsModel
{
    [Key]
    public int s_no { get; set; }
    public int full_marks { get; set; }
    public int pass_marks { get; set; }
    public DateOnly exam_date { get; set; }
    public TimeOnly time { get; set; }
    [ForeignKey("cid")]
    public virtual CourseModel CourseModel { get; set; }  
    public int cid { get; set; }
    [ForeignKey("eid")]
    public virtual ExamModel ExamModel { get; set; }  
    public int eid { get; set; }    
}