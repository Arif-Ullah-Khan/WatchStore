using System;
using System.Collections.Generic;

namespace OnlineWatchStore.Models;

public partial class Brand
{
    public string BrandName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
