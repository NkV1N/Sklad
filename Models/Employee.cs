using System;
using System.Collections.Generic;

namespace Warehouse.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Fio { get; set; } = null!;

    public DateOnly Date { get; set; }

    public string Pasport { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NumberPhone { get; set; } = null!;

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();
}
