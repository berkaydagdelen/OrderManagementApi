using AutoMapper;
using FluentValidation;
using OrderManagementApi.DataAccess.Abstract;
using OrderManagementApi.DataAccess.Entities;
using OrderManagementApi.DTO.Product.Dto;
using OrderManagementApi.DTO.Product.Request;
using OrderManagementApi.DTO.Product.Response;
using OrderManagementApi.Service.Abstract;
using OrderManagementApi.Service.Validator.Product;
using OrderManagementApi.Utility;

namespace OrderManagementApi.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
   
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductListResponse> List()
        {
            ProductListResponse response = new ProductListResponse();
            try
            {
                IList<Product> products = await _productRepository.GetAllAsync(p => p.IsActive == true);
                if (!products.Any())
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;

                }
                response.Products = _mapper.Map<List<ProductDto>>(products);
                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }

        public async Task<ProductSaveResponse> Save(ProductSaveRequest productSaveRequest)
        {
            ProductSaveResponse response = new ProductSaveResponse();
            try
            {
                ProductSaveRequestValidator validationRules = new ProductSaveRequestValidator();
                var validationResult = validationRules.Validate(productSaveRequest);
                if (!validationResult.IsValid)
                {
                    response.GenerateErrorResponse(MessageConstants.VALIDATION_ERROR);
                    return response;
                }

                Product product = _mapper.Map<Product>(productSaveRequest);
                product.CreatedById = 1;
                product.CreatedDate = DateTime.Now;
                product.IsActive = true;

                await _productRepository.AddAsync(product);

                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }

        public async Task<ProductDeleteResponse> Delete(ProductDeleteRequest productDeleteRequest)
        {
            ProductDeleteResponse response = new ProductDeleteResponse();
            try
            {
                Product product = await _productRepository.GetAsync(p => p.Id == productDeleteRequest.Id);

                if (product == null)
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;
                }

                product.IsActive = false;
                product.ModifiedById = 1;
                product.ModifiedDate = DateTime.Now;

                await _productRepository.UpdateAsync(product);

                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }


        public async Task<ProductUpdateResponse> Update(ProductUpdateRequest productUpdateRequest)
        {
            ProductUpdateResponse response = new ProductUpdateResponse();
            try
            {
                ProductUpdateRequestValidator validationRules = new ProductUpdateRequestValidator();
                var validationResult = validationRules.Validate(productUpdateRequest);
                if (!validationResult.IsValid)
                {
                    response.GenerateErrorResponse(MessageConstants.VALIDATION_ERROR);
                    return response;
                }

                Product product = await _productRepository.GetAsync(p => p.Id == productUpdateRequest.Id);
                if (product == null)
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;
                }

                product.Name = productUpdateRequest.Name;
                product.Price = productUpdateRequest.Price;
                product.Stock = productUpdateRequest.Stock;
                product.ModifiedById = 1;
                product.ModifiedDate = DateTime.Now;

                await _productRepository.UpdateAsync(product);

                response.GenerateSuccessResponse();
            }
            catch (Exception ex)
            {
                response.GenerateErrorResponse(ex.Message);
            }
            return response;
        }
      
        public async Task<ProductUpdateResponse> StockUpdate(ProductStockUpdateRequest producStocktUpdateRequest)
        {
            ProductUpdateResponse response = new ProductUpdateResponse();
            try
            {
                ProductStockUpdateRequestValidator validationRules = new ProductStockUpdateRequestValidator();
                var validationResult = validationRules.Validate(producStocktUpdateRequest);
                if (!validationResult.IsValid)
                {
                    response.GenerateErrorResponse(MessageConstants.VALIDATION_ERROR);
                    return response;
                }

                Product product = await _productRepository.GetAsync(p => p.Id == producStocktUpdateRequest.Id);
                if (product == null)
                {
                    response.GenerateErrorResponse(MessageConstants.RECORD_NOT_FOUND);
                    return response;
                }

                
                if (producStocktUpdateRequest.OldQuantity != producStocktUpdateRequest.Quantity)
                {
                    int diff = producStocktUpdateRequest.Quantity - producStocktUpdateRequest.OldQuantity;

                    if (diff > 0)
                    {
                        if (product.Stock < diff)
                        {
                            response.GenerateErrorResponse(MessageConstants.INSUFFICIENT_STOCK);
                            return response;
                        }
                        product.Stock -= diff;
                    }
                    else if (diff < 0)
                    {
                        product.Stock += Math.Abs(diff);
                    }
                }

          
                product.ModifiedById = 1;
                product.ModifiedDate = DateTime.Now;

                await _productRepository.UpdateAsync(product);

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