using System;
using System.Collections.Generic;

namespace OnlineWatchStore.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? BrandName { get; set; }

    public string? CategoryName { get; set; }

    public decimal? Price { get; set; }

    public virtual Brand? BrandNameNavigation { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category? CategoryNameNavigation { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
