using OrderManagementApi.DTO.Base;
using OrderManagementApi.DTO.OrderItem.Dto;

namespace OrderManagementApi.DTO.OrderItem.Response
{
    public class OrderItemListResponse : BaseResponse
    {
        public List<OrderItemDto>? OrderItems { get; set; }
    }
}