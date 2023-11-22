using System;
using System.Collections.Generic;

namespace Warehouse.Models;

public partial class Provider
{
    public string NumberProvider { get; set; } = null!;

    public int ProductId { get; set; }

    public int Count { get; set; }

    public double PriceProduct { get; set; }

    public DateOnly DateProvider { get; set; }

    public int ShipmentId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Shipment EmployeeNavigation { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
