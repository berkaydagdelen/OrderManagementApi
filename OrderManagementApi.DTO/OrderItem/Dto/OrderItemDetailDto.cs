using System.Text.Json.Serialization;

namespace OrderManagementApi.DTO.OrderItem.Dto
{
    public class OrderItemDetailDto
    {
        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonPropertyName("totalPrice")]
        public decimal? TotalPrice { get; set; }
    }
}