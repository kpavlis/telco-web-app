using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVC_Project.Models;

[Table("bills")]
public partial class Bill
{
    [Key]
    [Column("Bill_id")]
    public int BillId { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Column(TypeName = "decimal(7, 2)")]
    public decimal Costs { get; set; }

    public bool Payed { get; set; }

    [ForeignKey("PhoneNumber")]
    [InverseProperty("Bills")]
    public virtual Phone PhoneNumberNavigation { get; set; } = null!;
}
