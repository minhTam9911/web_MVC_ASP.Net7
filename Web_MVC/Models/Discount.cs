using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web_MVC.Models.MetaData;

namespace Web_MVC.Models;


public partial class Discount
{
    public int Id { get; set; }

    [Required]
    public double Precent { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
