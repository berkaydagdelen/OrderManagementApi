using Microsoft.EntityFrameworkCore;
using OrderManagementApi.Core.Repository;
using OrderManagementApi.DataAccess.Abstract;
using OrderManagementApi.DataAccess.Entities;

namespace OrderManagementApi.DataAccess.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }
    }
}
