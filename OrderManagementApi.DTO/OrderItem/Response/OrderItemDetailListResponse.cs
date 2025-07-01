using OrderManagementApi.DTO.Base;
using OrderManagementApi.DTO.OrderItem.Dto;
using System.Text.Json.Serialization;

namespace OrderManagementApi.DTO.OrderItem.Response
{
    public class OrderItemDetailListResponse : BaseResponse
    {
        [JsonPropertyName("orderItemDetails")]
        public List<OrderItemDetailDto>? OrderItemDetails { get; set; }
    }
}