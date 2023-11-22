using System;
using System.Collections.Generic;

namespace Warehouse.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int ProductTypeId { get; set; }

    public virtual ICollection<BalanceProduct> BalanceProducts { get; set; } = new List<BalanceProduct>();

    public virtual ProductType ProductType { get; set; } = null!;

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
