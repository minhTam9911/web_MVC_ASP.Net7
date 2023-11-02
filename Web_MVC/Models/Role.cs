using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_MVC.Models;

public partial class Role
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
