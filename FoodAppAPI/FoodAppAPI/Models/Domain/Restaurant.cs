using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodAppAPI.Models;

[Table("restaurants")]
[Index("RAddr", Name = "r_addr")]
public partial class Restaurant
{
    [Key]
    [Column("r_id", TypeName = "int(11)")]
    public int RId { get; set; }

    [Column("r_name")]
    [StringLength(100)]
    public string? RName { get; set; }

    [Column("r_addr", TypeName = "int(11)")]
    public int? RAddr { get; set; }

    [Column("r_email")]
    [StringLength(50)]
    public string REmail { get; set; } = null!;

    [InverseProperty("RIdNavigation")]
    public virtual ICollection<Cartitem> Cartitems { get; set; } = new List<Cartitem>();

    [InverseProperty("RIdNavigation")]
    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    [InverseProperty("RIdNavigation")]
    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    [InverseProperty("RIdNavigation")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("RAddr")]
    [InverseProperty("Restaurants")]
    public virtual Address? RAddrNavigation { get; set; }
}
