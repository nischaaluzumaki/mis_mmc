using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mis_mmc.Models;

public class ExamModel
{
    [Key]
    public int s_no { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public DateOnly start_date { get; set; }
    public DateOnly end_date { get; set; }
    public string sem_year { get; set; }
    [ForeignKey("pid")]
    public virtual ProgramModel ProgramModel { get; set; }  
    public int pid { get; set; }
    public virtual ICollection<ExamDetailsModel> ExamDetailsModels { get; set; }
}