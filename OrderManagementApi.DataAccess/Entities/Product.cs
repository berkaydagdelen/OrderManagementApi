using System;
using System.Collections.Generic;

namespace OrderManagementApi.DataAccess.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedById { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedById { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
