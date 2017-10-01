using FRS.Business.Common;
using FRS.DataModel.Entities;
using Kendo.Mvc.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace FRS.Business.Products
{
    public class ProductsService : BaseService, IProductsService
    {
        public ProductsService(DbContext context, ILogger<ProductsService> logger, ICacheProvider cacheProvider)
            : base(context, logger, cacheProvider)
        {
        }

        public DataSourceResult GetProducts(DataSourceRequest request)
        {
            return GetEntitiesForGrid<Product, ProductDto>(request);
        }

        public IEnumerable<ProductDto> CreateProducts(IEnumerable<ProductDto> dtos)
        {
            return CreateEntitiesForGrid<Product, ProductDto>(dtos);
        }

        public IEnumerable<ProductDto> UpdateProducts(IEnumerable<ProductDto> dtos)
        {
            return UpdateEntitiesForGrid<Product, ProductDto>(dtos);
        }

        public void DeleteProducts(IEnumerable<ProductDto> dtos)
        {
            DeleteEntitiesForGrid<Product, ProductDto>(dtos);
        }
    }
}
