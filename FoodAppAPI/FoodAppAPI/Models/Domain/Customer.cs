using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodAppAPI.Models;

[Table("customers")]
[Index("CAddr", Name = "c_addr")]
public partial class Customer
{
    [Key]
    [Column("c_id", TypeName = "int(11)")]
    public int CId { get; set; }

    [Column("c_name")]
    [StringLength(100)]
    public string? CName { get; set; }

    [Column("c_email")]
    [StringLength(50)]
    public string CEmail { get; set; } = null!;

    [Column("c_addr", TypeName = "int(11)")]
    public int? CAddr { get; set; }

    [ForeignKey("CAddr")]
    [InverseProperty("Customers")]
    public virtual Address? CAddrNavigation { get; set; }

    [InverseProperty("Cust")]
    public virtual ICollection<Cartitem> Cartitems { get; set; } = new List<Cartitem>();

    [InverseProperty("Cust")]
    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    [InverseProperty("CIdNavigation")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
