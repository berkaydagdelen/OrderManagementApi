using Microsoft.EntityFrameworkCore;
using OrderManagementApi.Core.Repository;
using OrderManagementApi.DataAccess.Abstract;
using OrderManagementApi.DataAccess.Entities;

namespace OrderManagementApi.DataAccess.Repository
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DbContext context) : base(context)
        {
        }
    }
}
