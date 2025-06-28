using OrderManagementApi.DTO.OrderItem.Request;
using OrderManagementApi.DTO.OrderItem.Response;

namespace OrderManagementApi.Service.Abstract
{
    public interface IOrderItemService
    {
        Task<OrderItemListResponse> List();
        Task<OrderItemDetailListResponse> OrderItemDetailList(OrderItemDetailListRequest orderItemListRequest);
        Task<OrderItemUserDetailListResponse> OrderItemUserDetailList(OrderItemUserDetailListRequest orderItemUserListRequest);
        Task<OrderItemSaveResponse> Save(OrderItemSaveRequest orderItemSaveRequest);
        Task<OrderItemDeleteResponse> Delete(OrderItemDeleteRequest orderItemDeleteRequest);
        Task<OrderItemDeleteResponse> DeleteRange(OrderItemDeleteRangeRequest orderItemDeleteRangeRequest);
        Task<OrderItemUpdateResponse> Update(OrderItemUpdateRequest orderItemUpdateRequest);
        Task<OrderItemGetResponse> OrderItemGet(OrderItemGetRequest orderItemGetRequest);
    }
}