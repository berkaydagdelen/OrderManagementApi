using Microsoft.AspNetCore.Mvc;
using OrderManagementApi.DTO.OrderItem.Response;
using OrderManagementApi.Service.Abstract;

namespace OrderManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderItemMainManagerService _orderItemMainManagerService;

        public OrdersController(IOrderItemMainManagerService orderItemMainManagerService)
        {
            _orderItemMainManagerService = orderItemMainManagerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            OrderItemDetailListResponse orderItemDetailListResponse = await _orderItemMainManagerService.GetOrders();
            return Ok(orderItemDetailListResponse);
        }
    }
}
