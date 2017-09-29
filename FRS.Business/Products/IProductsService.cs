using Kendo.Mvc.UI;
using System.Collections.Generic;

namespace FRS.Business.Products
{
    public interface IProductsService
    {
        DataSourceResult GetProducts(DataSourceRequest request);
        IEnumerable<ProductDto> CreateProducts(IEnumerable<ProductDto> dtos);
        IEnumerable<ProductDto> UpdateProducts(IEnumerable<ProductDto> dtos);
        void DeleteProducts(IEnumerable<ProductDto> dtos);
    }
}
