using AutoMapper;
using OrderManagementApi.DataAccess.Abstract;
using OrderManagementApi.DataAccess.Entities;
using OrderManagementApi.DTO.BedType.Request;
using OrderManagementApi.DTO.BedType.Response;
using OrderManagementApi.DTO.Order.Dto;
using OrderManagementApi.Service.Abstract;
using OrderManagementApi.Service.Validator.OrderValidator;
using OrderManagementApi.Utility;

namespace OrderManagementApi.Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderListResponse> List()
        {
            OrderListResponse response = new OrderListResponse();
            try
            {
                IList<Order> order = await _orderRepository.GetAllAsync(p => p.IsActive == true);
                if (!order.Any())
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;

                }
                response.Orders = _mapper.Map<List<OrderDto>>(order);
                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }


        public async Task<OrderSaveResponse> Save(OrderSaveRequest orderSaveRequest)
        {

            OrderSaveResponse response = new OrderSaveResponse();
            try
            {


                OrderSaveRequestValidator validationRules = new OrderSaveRequestValidator();
                var validationResult = validationRules.Validate(orderSaveRequest);
                if (!validationResult.IsValid)
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;
                }

                Order Order = _mapper.Map<Order>(orderSaveRequest);
                Order.CreatedById = 1;
                Order.CreatedDate = DateTime.Now;
                Order.IsActive = true;

                await _orderRepository.AddAsync(Order);



                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }
        public async Task<OrderDeleteResponse> Delete(OrderDeleteRequest OrderDeleteRequest)
        {
            OrderDeleteResponse response = new OrderDeleteResponse();
            try
            {
                Order Order = await _orderRepository.GetAsync(p => p.Id == OrderDeleteRequest.Id);

                if (Order == null)
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;
                }

                Order.IsActive = false;
                Order.ModifiedById = 1;
                Order.ModifiedDate = DateTime.Now;

                await _orderRepository.UpdateAsync(Order);


                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);

            }
            return response;
        }

     

        public async Task<OrderUpdateResponse> Update(OrderUpdateRequest OrderUpdateRequest)
        {
            OrderUpdateResponse response = new OrderUpdateResponse();
            try
            {
                OrderUpdateRequestValidator validationRules = new OrderUpdateRequestValidator();
                var validationResult = validationRules.Validate(OrderUpdateRequest);
                if (!validationResult.IsValid)
                {
                    response.GenerateErrorResponse(MessageConstants.VALIDATION_ERROR);
                    return response;
                }



                Order Order = await _orderRepository.GetAsync(p => p.Id == OrderUpdateRequest.Id);
                if (Order == null)
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;
                }

                Order.UserId = OrderUpdateRequest.UserId;
                Order.OrderDate = OrderUpdateRequest.OrderDate;
                Order.ModifiedById = 1;
                Order.ModifiedDate = DateTime.Now;
                await _orderRepository.UpdateAsync(Order);


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
