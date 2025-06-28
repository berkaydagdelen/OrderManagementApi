using OrderManagementApi.DTO.Base;

namespace OrderManagementApi.DTO.OrderItem.Response
{
    public class OrderItemGetResponse : BaseResponse
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}
