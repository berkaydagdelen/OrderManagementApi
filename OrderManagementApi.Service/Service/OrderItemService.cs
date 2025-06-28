using AutoMapper;
using OrderManagementApi.DataAccess.Abstract;
using OrderManagementApi.DataAccess.Entities;
using OrderManagementApi.DTO.OrderItem.Dto;
using OrderManagementApi.DTO.OrderItem.Request;
using OrderManagementApi.DTO.OrderItem.Response;
using OrderManagementApi.Service.Abstract;
using OrderManagementApi.Service.Validator.OrderItem;
using OrderManagementApi.Utility;
using System.Data;
using System.Net.Http.Headers;
using System.Net.Http;

namespace OrderManagementApi.Service.Service
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
  
 

        public OrderItemService(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderItemListResponse> List()
        {
            OrderItemListResponse response = new OrderItemListResponse();
            try
            {


                IList<OrderItem> orderItems = await _orderItemRepository.GetAllAsync(p => p.IsActive == true);

                if (!orderItems.Any())
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;

                }
                response.OrderItems = _mapper.Map<List<OrderItemDto>>(orderItems);
                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }

        public async Task<OrderItemUserDetailListResponse> OrderItemUserDetailList(OrderItemUserDetailListRequest orderItemUserListRequest)
        {
            OrderItemUserDetailListResponse response = new OrderItemUserDetailListResponse();
            try
            {
                IList<OrderItem> orderDetailItems = await _orderItemRepository.GetAllAsync(
                 oi => oi.IsActive == true && oi.Order.UserId == orderItemUserListRequest.UserId,
                 oi => oi.Order,
                 oi => oi.Product);

                if (!orderDetailItems.Any())
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;

                }

                response.OrderItemUserDetails = orderDetailItems.Select(oi => new OrderItemUserDetailDto
                {
                    OrderDate = oi.Order.OrderDate,
                    Name = oi.Product.Name,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    TotalPrice = oi.TotalPrice
                }).ToList();
                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }

        public async Task<OrderItemDetailListResponse> OrderItemDetailList(OrderItemDetailListRequest orderItemListRequest)
        {
            OrderItemDetailListResponse response = new OrderItemDetailListResponse();
            try
            {

                IList<OrderItem> orderDetailItems = await _orderItemRepository.GetAllAsync(
                 oi => oi.IsActive == true && oi.OrderId == orderItemListRequest.OrderId,
                 oi => oi.Order,
                 oi => oi.Product);

                if (!orderDetailItems.Any())
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;

                }

                response.OrderItemDetails = orderDetailItems.Select(oi => new OrderItemDetailDto
                {
                    OrderDate = oi.Order.OrderDate,
                    Name = oi.Product.Name,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    TotalPrice = oi.TotalPrice
                }).ToList();
                response.GenerateSuccessResponse();

            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }
        public async Task<OrderItemSaveResponse> Save(OrderItemSaveRequest orderItemSaveRequest)
        {
            OrderItemSaveResponse response = new OrderItemSaveResponse();
            try
            {
                var stockControl = await _orderItemRepository.GetAsync(p => p.IsActive == true && p.OrderId == orderItemSaveRequest.OrderId && p.ProductId == orderItemSaveRequest.ProductId);

                if (stockControl != null)
                {
                    response.GenerateErrorResponse(MessageConstants.DUPLICATE_PRODUCT_IN_ORDER);
                    return response;
                }



                OrderItemSaveRequestValidator validationRules = new OrderItemSaveRequestValidator();
                var validationResult = validationRules.Validate(orderItemSaveRequest);
                if (!validationResult.IsValid)
                {
                    response.GenerateErrorResponse(MessageConstants.VALIDATION_ERROR);
                    return response;
                }

                OrderItem orderItem = _mapper.Map<OrderItem>(orderItemSaveRequest);
                orderItem.TotalPrice = orderItemSaveRequest.Quantity * orderItemSaveRequest.UnitPrice;
                orderItem.CreatedById = 1;
                orderItem.CreatedDate = DateTime.Now;
                orderItem.IsActive = true;

                await _orderItemRepository.AddAsync(orderItem);

                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }

        public async Task<OrderItemDeleteResponse> Delete(OrderItemDeleteRequest orderItemDeleteRequest)
        {
            OrderItemDeleteResponse response = new OrderItemDeleteResponse();
            try
            {
                OrderItem orderItem = await _orderItemRepository.GetAsync(p => p.Id == orderItemDeleteRequest.Id);

                if (orderItem == null)
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;
                }

                orderItem.IsActive = false;
                orderItem.ModifiedById = 1;
                orderItem.ModifiedDate = DateTime.Now;

                await _orderItemRepository.UpdateAsync(orderItem);

                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }
        public async Task<OrderItemDeleteResponse> DeleteRange(OrderItemDeleteRangeRequest orderItemDeleteRangeRequest)
        {
            OrderItemDeleteResponse response = new OrderItemDeleteResponse();
            try
            {
                IList<OrderItem> orderItems = await _orderItemRepository.GetAllAsync(p => p.IsActive == true && p.OrderId == orderItemDeleteRangeRequest.OrderId);

                if (!orderItems.Any())
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;

                }
                foreach (OrderItem orderItem in orderItems)
                {
                    orderItem.IsActive = false;
                    orderItem.ModifiedById = 1;
                    orderItem.ModifiedDate = DateTime.Now;


                    await _orderItemRepository.UpdateAsync(orderItem);
                }


                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }


        public async Task<OrderItemUpdateResponse> Update(OrderItemUpdateRequest orderItemUpdateRequest)
        {
            OrderItemUpdateResponse response = new OrderItemUpdateResponse();
            try
            {
                OrderItemUpdateRequestValidator validationRules = new OrderItemUpdateRequestValidator();
                var validationResult = validationRules.Validate(orderItemUpdateRequest);
                if (!validationResult.IsValid)
                {
                    response.GenerateErrorResponse(MessageConstants.VALIDATION_ERROR);
                    return response;
                }

                OrderItem orderItem = await _orderItemRepository.GetAsync(p => p.Id == orderItemUpdateRequest.Id);
                if (orderItem == null)
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;
                }

                orderItem.OrderId = orderItemUpdateRequest.OrderId;
                orderItem.ProductId = orderItemUpdateRequest.ProductId;
                orderItem.Quantity = orderItemUpdateRequest.Quantity;
                orderItem.UnitPrice = orderItemUpdateRequest.UnitPrice;
                orderItem.TotalPrice = orderItem.Quantity * orderItem.UnitPrice;
                orderItem.ModifiedById = 1;
                orderItem.ModifiedDate = DateTime.Now;

                await _orderItemRepository.UpdateAsync(orderItem);

                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }

        public async Task<OrderItemGetResponse> OrderItemGet(OrderItemGetRequest orderItemGetRequest)
        {
            OrderItemGetResponse response = new OrderItemGetResponse();

            try
            {
                OrderItem orderItem = await _orderItemRepository.GetAsync(p => p.Id == orderItemGetRequest.Id);

                if (orderItem == null)
                {

                    response.GenerateErrorResponse(MessageConstants.VALIDATION_ERROR);
                    return response;
                }
                response.Id = orderItem.Id;
                response.OrderId = orderItem.OrderId;
                response.ProductId = orderItem.ProductId;
                response.Quantity = orderItem.Quantity;
                response.UnitPrice = orderItem.UnitPrice;
                response.TotalPrice = orderItem.TotalPrice;

                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }
    }
}