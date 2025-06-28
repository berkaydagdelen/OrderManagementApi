using Microsoft.AspNetCore.Mvc;
using OrderManagementApi.DTO.Product.Request;
using OrderManagementApi.DTO.Product.Response;
using OrderManagementApi.Service.Abstract;

namespace OrderManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ProductListResponse>> List()
        {
            ProductListResponse productListResponse = await _productService.List();
            return Ok(productListResponse);
        }
     
        [HttpPost]
        public async Task<ActionResult<ProductSaveResponse>> Save([FromBody] ProductSaveRequest productSaveRequest)
        {
            ProductSaveResponse productSaveResponse = await _productService.Save(productSaveRequest);
            return Ok(productSaveResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ProductDeleteResponse>> Delete([FromBody] ProductDeleteRequest productDeleteRequest)
        {

            ProductDeleteResponse productDeleteResponse = await _productService.Delete(productDeleteRequest);
            return Ok(productDeleteResponse);
        }
       

        [HttpPut]
        public async Task<ActionResult<ProductUpdateResponse>> Update([FromBody] ProductUpdateRequest productUpdateRequest)
        {

            ProductUpdateResponse productUpdateResponse = await _productService.Update(productUpdateRequest);
            return Ok(productUpdateResponse);
        }

    }
}
