using System;
using System.Collections.Generic;

namespace Warehouse.Models;

public partial class Manager
{
    public int ManagerId { get; set; }

    public string Fio { get; set; } = null!;

    public DateOnly Date { get; set; }

    public string Pasport { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NumberPhone { get; set; } = null!;

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
