using System;
using System.Collections.Generic;

namespace Web_MVC.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Avatar { get; set; }

    public bool? IsActive { get; set; }

    public string? SecurityCode { get; set; }

    public int RoleId { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual ICollection<Apitoken> Apitokens { get; set; } = new List<Apitoken>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;
}
