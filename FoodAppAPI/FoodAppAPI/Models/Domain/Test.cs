using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodAppAPI.Models;

[Table("test")]
public partial class Test
{
    [Key]
    [Column("t_id")]
    public Guid TId { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string? Name { get; set; }
}
