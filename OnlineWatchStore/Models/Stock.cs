﻿using System;
using System.Collections.Generic;

namespace OnlineWatchStore.Models;

public partial class Stock
{
    public int StockId { get; set; }

    public int? ProductId { get; set; }

    public int? QuantityAvailable { get; set; }

    public virtual Product? Product { get; set; }
}
