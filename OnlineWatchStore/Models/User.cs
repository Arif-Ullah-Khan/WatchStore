﻿using System;
using System.Collections.Generic;

namespace OnlineWatchStore.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Paswd { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
