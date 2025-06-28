using OrderManagementApi.DTO.OrderItem.Request;
using OrderManagementApi.DTO.OrderItem.Response;

namespace OrderManagementApi.Service.Abstract
{
    public interface IOrderItemMainManagerService
    {
        Task<OrderItemSaveResponse> Save(OrderItemSaveRequest orderItemSaveRequest);

        Task<OrderItemUpdateResponse> Update(OrderItemUpdateRequest orderItemUpdateRequest);
    }
}