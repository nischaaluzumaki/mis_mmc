using System.ComponentModel.DataAnnotations;


namespace mis_mmc.Models;

public class LoginModel
{
    [Key]
    public int uid { get; set; }


    [Required]
    public string email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string password { get; set; }
    public string role { get; set; }
    
}