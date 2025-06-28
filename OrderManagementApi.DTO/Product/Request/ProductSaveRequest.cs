namespace OrderManagementApi.DTO.Product.Request
{
    public class ProductSaveRequest
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
} 