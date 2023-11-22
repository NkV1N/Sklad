using System;
using System.Collections.Generic;

namespace Warehouse.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NumberPhone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
