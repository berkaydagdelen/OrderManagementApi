using OrderManagementApi.DTO.BedType.Request;
using OrderManagementApi.DTO.BedType.Response;
using OrderManagementApi.DTO.OrderItem.Request;
using OrderManagementApi.DTO.OrderItem.Response;
using OrderManagementApi.Service.Abstract;

namespace OrderManagementApi.Service.Service
{
    public class OrderMainManagerService : IOrderMainManagerService
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;

        public OrderMainManagerService(IOrderService orderService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
        }

        public async Task<OrderDeleteResponse> DeleteRange(OrderDeleteRequest orderDeleteRequest)
        {
            OrderDeleteResponse orderDeleteResponse = await _orderService.Delete(orderDeleteRequest);
            if (!orderDeleteResponse.State)
            {
                return orderDeleteResponse;
            }

            OrderItemDeleteRangeRequest orderItemDeleteRangeRequest = new OrderItemDeleteRangeRequest
            {
                OrderId = orderDeleteRequest.Id
            };
            OrderItemDeleteResponse orderItemDeleteResponse = await _orderItemService.DeleteRange(orderItemDeleteRangeRequest);
            if (!orderItemDeleteResponse.State)
            {

                orderDeleteResponse.GenerateErrorResponse(orderItemDeleteResponse.ErrorMessage);
                return orderDeleteResponse;
            }
            return orderDeleteResponse;

        }
    }
}
