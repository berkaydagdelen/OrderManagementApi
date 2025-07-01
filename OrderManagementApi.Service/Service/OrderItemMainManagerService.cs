
using Microsoft.Extensions.Configuration;
using OrderManagementApi.DTO.OrderItem.Request;
using OrderManagementApi.DTO.OrderItem.Response;
using OrderManagementApi.DTO.Product.Request;
using OrderManagementApi.DTO.Product.Response;
using OrderManagementApi.Service.Abstract;
using OrderManagementApi.Utility;
using System.Net.Http.Headers;
using System.Text.Json;

namespace OrderManagementApi.Service.Service
{
    public class OrderItemMainManagerService : IOrderItemMainManagerService
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IProductService _productService;
        private readonly HttpClient _httpClient;
        private readonly TokenCacheService _tokenCache;
        private readonly IConfiguration _configuration;

        public OrderItemMainManagerService(IOrderItemService orderItemService, IProductService productService, HttpClient httpClient, TokenCacheService tokenCache, IConfiguration configuration)
        {
            _orderItemService = orderItemService;
            _productService = productService;
            _httpClient = httpClient;
            _tokenCache = tokenCache;
            _configuration = configuration;
        }

        public async Task<OrderItemDetailListResponse> GetOrders()
        {
            OrderItemDetailListResponse orderItemDetailListResponse = new OrderItemDetailListResponse();


            var token = await _tokenCache.GetToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(_configuration["OrderApi:OrderListUrl"]);
            if (!response.IsSuccessStatusCode)
            {
                orderItemDetailListResponse.GenerateErrorResponse(MessageConstants.RATE_LIMIT_EXCEEDED);
                return orderItemDetailListResponse;
            }
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<OrderItemDetailListResponse>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (result != null)
            {
                orderItemDetailListResponse = result;
            }
            else
            {
                orderItemDetailListResponse.GenerateErrorResponse(MessageConstants.RESPONSE_DESERIALIZE_ERROR);
            }

            return orderItemDetailListResponse;
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
