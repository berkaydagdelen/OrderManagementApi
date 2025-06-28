using OrderManagementApi.DTO.Base;
using OrderManagementApi.DTO.Product.Dto;

namespace OrderManagementApi.DTO.Product.Response
{
    public class ProductListResponse : BaseResponse
    {
        public List<ProductDto>? Products { get; set; }
    }
} 