using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodAppAPI.Models;

[Table("deliverers")]
[Index("DAddr", Name = "d_addr")]
public partial class Deliverer
{
    [Key]
    [Column("d_id", TypeName = "int(11)")]
    public int DId { get; set; }

    [Column("d_name")]
    [StringLength(100)]
    public string? DName { get; set; }

    [Column("d_addr", TypeName = "int(11)")]
    public int? DAddr { get; set; }

    [Column("d_email")]
    [StringLength(50)]
    public string DEmail { get; set; } = null!;

    [ForeignKey("DAddr")]
    [InverseProperty("Deliverers")]
    public virtual Address? DAddrNavigation { get; set; }
}
