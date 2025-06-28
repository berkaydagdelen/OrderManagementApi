using OrderManagementApi.DTO.Base;
using OrderManagementApi.DTO.Order.Dto;

namespace OrderManagementApi.DTO.BedType.Response
{
    public class OrderListResponse : BaseResponse
    {
        public List<OrderDto>? Orders { get; set; }
    }


}
