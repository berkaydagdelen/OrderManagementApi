using OrderManagementApi.DTO.Product.Request;
using OrderManagementApi.DTO.Product.Response;

namespace OrderManagementApi.Service.Abstract
{
    public interface IProductService
    {
        Task<ProductListResponse> List();
        Task<ProductSaveResponse> Save(ProductSaveRequest productSaveRequest);
        Task<ProductDeleteResponse> Delete(ProductDeleteRequest productDeleteRequest);
        Task<ProductUpdateResponse> Update(ProductUpdateRequest productUpdateRequest);
        Task<ProductUpdateResponse> StockUpdate(ProductStockUpdateRequest productStockUpdateRequest);
    }
} 