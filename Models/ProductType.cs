using System;
using System.Collections.Generic;

namespace Warehouse.Models;

public partial class ProductType
{
    public int ProductTypyId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
