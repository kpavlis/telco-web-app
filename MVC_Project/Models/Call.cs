using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Project.Models;

[Table("calls")]
public partial class Call
{
    [Key]
    [Column("Call_Id")]
    public int CallId { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Column("Bill_Id")]
    public int? BillId { get; set; }

    [Column(TypeName = "text")]
    public string Description { get; set; } = null!;

    [ForeignKey("PhoneNumber")]
    [InverseProperty("Calls")]
    public virtual Phone PhoneNumberNavigation { get; set; } = null!;
}
