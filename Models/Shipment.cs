using System;
using System.Collections.Generic;

namespace Warehouse.Models;

public partial class Shipment
{
    public int ShipmentId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NumberPhone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();
}
