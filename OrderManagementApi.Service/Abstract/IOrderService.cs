using OrderManagementApi.DTO.BedType.Request;
using OrderManagementApi.DTO.BedType.Response;

namespace OrderManagementApi.Service.Abstract
{
    public interface IOrderService
    {
        Task<OrderListResponse> List();
        Task<OrderSaveResponse> Save(OrderSaveRequest orderSaveRequest);
        Task<OrderDeleteResponse> Delete(OrderDeleteRequest orderDeleteRequest);
        Task<OrderUpdateResponse> Update(OrderUpdateRequest orderUpdateRequest);
    }
}
