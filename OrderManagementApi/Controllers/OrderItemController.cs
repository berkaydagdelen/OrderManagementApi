using Microsoft.AspNetCore.Mvc;
using OrderManagementApi.DTO.OrderItem.Request;
using OrderManagementApi.DTO.OrderItem.Response;
using OrderManagementApi.Service.Abstract;

namespace OrderManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IOrderItemMainManagerService _orderItemainManagerService;

        public OrderItemController(IOrderItemService orderItemService, IOrderItemMainManagerService orderItemainManagerService)
        {
            _orderItemService = orderItemService;
            _orderItemainManagerService = orderItemainManagerService;
        }
        [HttpGet]
        public async Task<ActionResult<OrderItemListResponse>> List()
        {

            OrderItemListResponse orderItemListResponse = await _orderItemService.List();
            return Ok(orderItemListResponse);
        }
       
        [HttpPost]
        public async Task<ActionResult<OrderItemSaveResponse>> Save(OrderItemSaveRequest orderItemSaveRequest)
        {
            OrderItemSaveResponse orderItemSaveResponse = await _orderItemainManagerService.Save(orderItemSaveRequest);
            return Ok(orderItemSaveResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<OrderItemDeleteResponse>> Delete(OrderItemDeleteRequest orderItemDeleteRequest)
        {
            OrderItemDeleteResponse orderItemDeleteResponse = await _orderItemService.Delete(orderItemDeleteRequest);
            return Ok(orderItemDeleteResponse);
        }

      
        [HttpPut]
        public async Task<ActionResult<OrderItemUpdateResponse>> Update(OrderItemUpdateRequest orderItemUpdateRequest)
        {
            OrderItemUpdateResponse orderItemUpdateResponse = await _orderItemainManagerService.Update(orderItemUpdateRequest);
            return Ok(orderItemUpdateResponse);
        }
    }
}
