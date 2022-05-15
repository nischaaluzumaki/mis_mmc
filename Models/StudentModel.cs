using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mis_mmc.Models;

public class StudentModel
{
    [Key]
    public int s_no { get; set; }
    public string name { get; set; }
    public int phone { get; set; }
    public DateTime dob { get; set; }
    public string? file { get; set; }
    public string gender { get; set; }
    public string address { get; set; }
    [ForeignKey("userlogin")]
    public String email { get; set; }  
    
}