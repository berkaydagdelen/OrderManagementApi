namespace OrderManagementApi.DTO.OrderItem.Request
{
    public class OrderItemSaveRequest
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
} 