namespace OrderManagementApi.DTO.OrderItem.Dto
{
    public class OrderItemDetailDto
    {

        public DateTime OrderDate { get; set; }
        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? TotalPrice { get; set; }




    }
}