using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodAppAPI.Models;

[Table("dishes")]
[Index("DCateg", Name = "d_categ")]
public partial class Dish
{
    [Key]
    [Column("d_id", TypeName = "int(11)")]
    public int DId { get; set; }

    [Column("d_name")]
    [StringLength(100)]
    public string DName { get; set; } = null!;

    [Column("is_non_veg")]
    public bool IsNonVeg { get; set; }

    [Column("d_categ", TypeName = "int(11)")]
    public int DCateg { get; set; }

    [InverseProperty("DIdNavigation")]
    public virtual ICollection<Cartitem> Cartitems { get; set; } = new List<Cartitem>();

    [ForeignKey("DCateg")]
    [InverseProperty("Dishes")]
    public virtual Category DCategNavigation { get; set; } = null!;

    [InverseProperty("DIdNavigation")]
    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    [InverseProperty("DIdNavigation")]
    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();
}
