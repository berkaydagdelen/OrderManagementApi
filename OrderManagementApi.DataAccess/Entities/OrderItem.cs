using System;
using System.Collections.Generic;

namespace OrderManagementApi.DataAccess.Entities;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedById { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedById { get; set; }

    public bool? IsActive { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
