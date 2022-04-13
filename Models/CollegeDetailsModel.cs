using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mis_mmc.Models;


public class CollegeDetails
{
    [Key] 
    public int s_no { get; set; }
    public string college_name { get; set; }
    public int phone_number_one { get; set; }
    public string email { get; set; }
    public string logo { get; set; }
    public string address { get; set; }
}