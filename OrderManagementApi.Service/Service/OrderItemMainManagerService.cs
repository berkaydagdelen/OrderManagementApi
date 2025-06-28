
using OrderManagementApi.DTO.OrderItem.Request;
using OrderManagementApi.DTO.OrderItem.Response;
using OrderManagementApi.DTO.Product.Request;
using OrderManagementApi.DTO.Product.Response;
using OrderManagementApi.Service.Abstract;

namespace OrderManagementApi.Service.Service
{
    public class OrderItemMainManagerService : IOrderItemMainManagerService
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IProductService _productService;

        public OrderItemMainManagerService(IOrderItemService orderItemService, IProductService productService)
        {
            _orderItemService = orderItemService;
            _productService = productService;
        }

       
        public async Task<OrderItemSaveResponse> Save(OrderItemSaveRequest orderItemSaveRequest)
        {
            OrderItemSaveResponse response = new OrderItemSaveResponse();

            ProductStockUpdateRequest productStockUpdateRequest = new ProductStockUpdateRequest
            {
                Id = orderItemSaveRequest.ProductId,
                Quantity = orderItemSaveRequest.Quantity
            };
            ProductUpdateResponse productUpdateResponse = await _productService.StockUpdate(productStockUpdateRequest);
            if (!productUpdateResponse.State)
            {
                response.GenerateErrorResponse(productUpdateResponse.ErrorMessage);
                return response;
            }

            response = await _orderItemService.Save(orderItemSaveRequest);

            return response;
        }

        public async Task<OrderItemUpdateResponse> Update(OrderItemUpdateRequest orderItemUpdateRequest)
        {
            OrderItemUpdateResponse response = new OrderItemUpdateResponse();

            OrderItemGetRequest orderItemGetRequest = new OrderItemGetRequest
            {
                Id = orderItemUpdateRequest.Id

            };
            OrderItemGetResponse orderItemGetResponse = await _orderItemService.OrderItemGet(orderItemGetRequest);
            if (!orderItemGetResponse.State)
            {
                response.GenerateErrorResponse(orderItemGetResponse.ErrorMessage);
                return response;
            }


            ProductStockUpdateRequest productStockUpdateRequest = new ProductStockUpdateRequest
            {
                Id = orderItemUpdateRequest.ProductId,
                Quantity = orderItemUpdateRequest.Quantity,
                OldQuantity = orderItemGetResponse.Quantity

            };
            ProductUpdateResponse productUpdateResponse = await _productService.StockUpdate(productStockUpdateRequest);
            if (!productUpdateResponse.State)
            {
                response.GenerateErrorResponse(productUpdateResponse.ErrorMessage);
                return response;
            }

            response = await _orderItemService.Update(orderItemUpdateRequest);

            return response;
        }
    }
}
