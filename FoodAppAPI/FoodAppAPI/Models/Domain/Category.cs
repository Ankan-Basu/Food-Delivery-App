using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodAppAPI.Models;

[Table("categories")]
public partial class Category
{
    [Key]
    [Column("cat_id", TypeName = "int(11)")]
    public int CatId { get; set; }

    [Column("cat_name")]
    [StringLength(50)]
    public string CatName { get; set; } = null!;

    [InverseProperty("DCategNavigation")]
    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}
