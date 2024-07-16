using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodAppAPI.Models;

[PrimaryKey("RId", "DId")]
[Table("menus")]
[Index("DId", Name = "d_id")]
public partial class Menu
{
    [Key]
    [Column("d_id", TypeName = "int(11)")]
    public int DId { get; set; }

    [Key]
    [Column("r_id", TypeName = "int(11)")]
    public int RId { get; set; }

    [Column("price")]
    [Precision(6)]
    public decimal Price { get; set; }

    [ForeignKey("DId")]
    [InverseProperty("Menus")]
    public virtual Dish DIdNavigation { get; set; } = null!;

    [ForeignKey("RId")]
    [InverseProperty("Menus")]
    public virtual Restaurant RIdNavigation { get; set; } = null!;
}
