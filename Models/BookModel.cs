using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mis_mmc.Models;

public class BookModel
{
    [Key]
    public int s_no { get; set; }
    public string name { get; set; }
    public string author { get; set; }
    public string publication { get; set; }
    public int stock { get; set; }
    [DefaultValue(false)]
    public bool? is_issued { get; set; }
    public int? sem_year { get; set; }
    public string type { get; set; }

    [ForeignKey("pid")]
    public virtual ProgramModel? ProgramModel { get; set; }
    public int? pid { get; set; }







}