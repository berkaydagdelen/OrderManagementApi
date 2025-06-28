using OrderManagementApi.Core.Repository;
using OrderManagementApi.DataAccess.Entities;

namespace OrderManagementApi.DataAccess.Abstract
{
    public interface IOrderItemRepository : IRepositoryBase<OrderItem>
    {
    }
}
