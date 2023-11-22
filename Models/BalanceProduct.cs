using System;
using System.Collections.Generic;

namespace Warehouse.Models;

public partial class BalanceProduct
{
    public int BalanceProductId { get; set; }

    public int ProductId { get; set; }

    public double ProviderPrice { get; set; }

    public double SupplierPrice { get; set; }

    public int Count { get; set; }

    public virtual Product Product { get; set; } = null!;
}
