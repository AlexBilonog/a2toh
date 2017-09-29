using FRS.Business.Products;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FRS.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public DataSourceResult GetProducts([DataSourceRequest]DataSourceRequest request)
        {
            return _productsService.GetProducts(request);
        }

        [HttpPost]
        public IEnumerable<ProductDto> CreateProducts([FromBody]IEnumerable<ProductDto> dtos)
        {
            return _productsService.CreateProducts(dtos);
        }

        [HttpPut]
        public IEnumerable<ProductDto> UpdateProducts([FromBody]IEnumerable<ProductDto> dtos)
        {
            return _productsService.UpdateProducts(dtos);
        }

        [HttpDelete]
        public void DeleteProducts([FromBody]IEnumerable<ProductDto> dtos)
        {
            _productsService.DeleteProducts(dtos);
        }
    }
}
