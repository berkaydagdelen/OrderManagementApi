using System;
using System.Collections.Generic;

namespace OrderManagementApi.DataAccess.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Surname { get; set; }

    public string Email { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public int? CreatedById { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedById { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
