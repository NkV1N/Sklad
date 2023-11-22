using System;
using System.Collections.Generic;

namespace Warehouse.Models;

public partial class Supplier
{
    public string NumberSupplier { get; set; } = null!;

    public int ProductId { get; set; }

    public int Price { get; set; }

    public int Count { get; set; }

    public DateOnly DateSupplier { get; set; }

    public int ClientId { get; set; }

    public int ManagerId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Manager Manager { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
