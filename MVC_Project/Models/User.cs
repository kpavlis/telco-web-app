using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Project.Models;

[Table("users")]
[Index("Username", Name = "UQ_username", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("User_id")]
    public int UserId { get; set; }

    [Column("First_Name")]
    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("Last_Name")]
    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Property { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    [InverseProperty("User")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    [InverseProperty("User")]
    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
