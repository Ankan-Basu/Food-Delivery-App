using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodAppAPI.Models;

[Table("addresses")]
public partial class Address
{
    [Key]
    [Column("addr_id", TypeName = "int(11)")]
    public int AddrId { get; set; }

    [Column("line1")]
    [StringLength(100)]
    public string Line1 { get; set; } = null!;

    [Column("line2")]
    [StringLength(100)]
    public string? Line2 { get; set; }

    [Column("line3")]
    [StringLength(100)]
    public string? Line3 { get; set; }

    [Column("city")]
    [StringLength(50)]
    public string City { get; set; } = null!;

    [Column("state")]
    [StringLength(50)]
    public string State { get; set; } = null!;

    [Column("country")]
    [StringLength(50)]
    public string Country { get; set; } = null!;

    [Column("pin")]
    [StringLength(6)]
    public string Pin { get; set; } = null!;

    [InverseProperty("CAddrNavigation")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("DAddrNavigation")]
    public virtual ICollection<Deliverer> Deliverers { get; set; } = new List<Deliverer>();

    [InverseProperty("RAddrNavigation")]
    public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
}
