using Microsoft.AspNetCore.Mvc;
using OrderManagementApi.DTO.BedType.Request;
using OrderManagementApi.DTO.BedType.Response;
using OrderManagementApi.DTO.OrderItem.Request;
using OrderManagementApi.DTO.OrderItem.Response;
using OrderManagementApi.Service.Abstract;

namespace OrderManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IOrderMainManagerService _orderMainManagerService;
        public OrderController(IOrderService orderService, IOrderMainManagerService orderMainManagerService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _orderMainManagerService = orderMainManagerService;
            _orderItemService = orderItemService;
        }
        [HttpGet]
        public async Task<ActionResult<OrderListResponse>> List()
        {

            OrderListResponse orderListResponse = await _orderService.List();
            return Ok(orderListResponse);
        }
        [HttpPost("OrderItemUserDetailList")]
        public async Task<ActionResult<OrderItemUserDetailListResponse>> OrderItemUserDetailList(OrderItemUserDetailListRequest orderItemUserListRequest)
        {

            OrderItemUserDetailListResponse orderItemUserDetailListResponse = await _orderItemService.OrderItemUserDetailList(orderItemUserListRequest);
            return Ok(orderItemUserDetailListResponse);
        }
        [HttpPost("OrderItemDetailList")]
        public async Task<ActionResult<OrderItemUserDetailListResponse>> OrderItemDetailList(OrderItemDetailListRequest orderItemListRequest)
        {

            OrderItemDetailListResponse orderItemDetailListResponse = await _orderItemService.OrderItemDetailList(orderItemListRequest);
            return Ok(orderItemDetailListResponse);
        }
        [HttpPost]
        public async Task<ActionResult<OrderSaveResponse>> Save(OrderSaveRequest orderSaveRequest)
        {
            OrderSaveResponse orderSaveResponse = await _orderService.Save(orderSaveRequest);
            return Ok(orderSaveResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<OrderDeleteResponse>> Delete(OrderDeleteRequest orderDeleteRequest)
        {
            OrderDeleteResponse orderDeleteResponse = await _orderService.Delete(orderDeleteRequest);
            return Ok(orderDeleteResponse);
        }
        [HttpDelete("DeleteRange")]
        public async Task<ActionResult<OrderDeleteResponse>> DeleteRange(OrderDeleteRequest orderDeleteRequest)
        {
            OrderDeleteResponse orderDeleteResponse = await _orderMainManagerService.DeleteRange(orderDeleteRequest);
            return Ok(orderDeleteResponse);
        }
      
        [HttpPut]
        public async Task<ActionResult<OrderUpdateResponse>> Update(OrderUpdateRequest orderUpdateRequest)
        {
            OrderUpdateResponse orderUpdateResponse = await _orderService.Update(orderUpdateRequest);
            return Ok(orderUpdateResponse);
        }
    }
}
