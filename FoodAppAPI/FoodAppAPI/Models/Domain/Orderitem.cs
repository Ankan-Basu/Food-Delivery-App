using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodAppAPI.Models;

[PrimaryKey("CustId", "RId", "DId")]
[Table("orderitems")]
[Index("DId", Name = "d_id")]
[Index("OId", Name = "o_id")]
[Index("RId", Name = "r_id")]
public partial class Orderitem
{
    [Key]
    [Column("cust_id", TypeName = "int(11)")]
    public int CustId { get; set; }

    [Key]
    [Column("r_id", TypeName = "int(11)")]
    public int RId { get; set; }

    [Key]
    [Column("d_id", TypeName = "int(11)")]
    public int DId { get; set; }

    [Column("d_qn", TypeName = "int(11)")]
    public int? DQn { get; set; }

    [Column("cost")]
    [Precision(10)]
    public decimal Cost { get; set; }

    [Column("o_id")]
    public Guid OId { get; set; }

    [ForeignKey("CustId")]
    [InverseProperty("Orderitems")]
    public virtual Customer Cust { get; set; } = null!;

    [ForeignKey("DId")]
    [InverseProperty("Orderitems")]
    public virtual Dish DIdNavigation { get; set; } = null!;

    [ForeignKey("OId")]
    [InverseProperty("Orderitems")]
    public virtual Order OIdNavigation { get; set; } = null!;

    [ForeignKey("RId")]
    [InverseProperty("Orderitems")]
    public virtual Restaurant RIdNavigation { get; set; } = null!;
}
