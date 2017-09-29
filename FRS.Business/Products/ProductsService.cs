﻿using FRS.Business.Common;
using FRS.DataModel.Entities;
using Kendo.Mvc.Extensions;
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
            return Context.Set<User>().ToDataSourceResult(request);
        }

        public IEnumerable<ProductDto> CreateProducts(IEnumerable<ProductDto> dtos)
        {
            return CreateEntitiesForGrid<User, ProductDto>(dtos);
        }

        public IEnumerable<ProductDto> UpdateProducts(IEnumerable<ProductDto> dtos)
        {
            return UpdateEntitiesForGrid<User, ProductDto>(dtos);
        }

        public void DeleteProducts(IEnumerable<ProductDto> dtos)
        {
            DeleteEntitiesForGrid<User, ProductDto>(dtos);
        }
    }
}
