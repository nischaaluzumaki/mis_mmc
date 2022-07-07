using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mis_mmc.Models;

public class BookIssueModel
{
    [Key]
    public int s_no { get; set; }
    public string uid { get; set; }
    public DateOnly? issued_date { get; set; }
    public DateOnly expiry_date { get; set; }
    public bool? is_returned { get; set; }
    public DateOnly? return_date { get; set; }
    [ForeignKey("sid")]
    public virtual StudentModel StudentModel { get; set; }
    public int sid { get; set; }

    [ForeignKey("bid")]
    public virtual BookModel BookModel { get; set; }
    public int bid { get; set; }

}