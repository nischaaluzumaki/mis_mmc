using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mis_mmc.Models;

public class StudentModel
{
    [Key]
    public int s_no { get; set; }

    public string uid { get; set; }  
    public string name { get; set; }
    public int phone { get; set; }
    public DateOnly dob { get; set; }
    public string? file { get; set; }
    public string gender { get; set; }
    public string address { get; set; }
    public bool is_admitted { get; set; }
    public int sem_year { get; set; }
    public String email { get; set; }  
    /*public virtual ICollection<BookModel> BookModels { get; set; }*/

    [ForeignKey("pid")]
    public virtual ProgramModel? ProgramModel  { get; set; }
    public  int? pid{get; set;}
}