using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Project.Models;

[Table("phones")]
public partial class Phone
{
    [Key]
    [StringLength(15)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Column("Program_Name")]
    [StringLength(50)]
    [Unicode(false)]
    public string ProgramName { get; set; } = null!;

    [InverseProperty("PhoneNumberNavigation")]
    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    [InverseProperty("PhoneNumberNavigation")]
    public virtual ICollection<Call> Calls { get; set; } = new List<Call>();

    [InverseProperty("PhoneNumberNavigation")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    [ForeignKey("ProgramName")]
    [InverseProperty("Phones")]
    public virtual Program ProgramNameNavigation { get; set; } = null!;
}
