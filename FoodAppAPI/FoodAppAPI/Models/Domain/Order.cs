using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodAppAPI.Models;

[Table("orders")]
[Index("CId", Name = "c_id")]
[Index("RId", Name = "r_id")]
public partial class Order
{
    [Key]
    [Column("o_id")]
    public Guid OId { get; set; }

    [Column("r_id", TypeName = "int(11)")]
    public int RId { get; set; }

    [Column("c_id", TypeName = "int(11)")]
    public int CId { get; set; }

    [Column("status")]
    [StringLength(10)]
    public string Status { get; set; } = null!;

    [Column("o_date", TypeName = "datetime")]
    public DateTime? ODate { get; set; }

    [ForeignKey("CId")]
    [InverseProperty("Orders")]
    public virtual Customer CIdNavigation { get; set; } = null!;

    [InverseProperty("OIdNavigation")]
    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    [ForeignKey("RId")]
    [InverseProperty("Orders")]
    public virtual Restaurant RIdNavigation { get; set; } = null!;
}
