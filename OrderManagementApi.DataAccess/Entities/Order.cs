using System;
using System.Collections.Generic;

namespace OrderManagementApi.DataAccess.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedById { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedById { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;
}
