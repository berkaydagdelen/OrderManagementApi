using OrderManagementApi.DTO.BedType.Request;
using OrderManagementApi.DTO.BedType.Response;

namespace OrderManagementApi.Service.Abstract
{
    public interface IOrderMainManagerService
    {
        Task<OrderDeleteResponse> DeleteRange(OrderDeleteRequest orderDeleteRequest);
     
    }
}
