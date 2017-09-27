using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Angular2Spa.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        //private readonly SampleContext _context;

        private static List<Product> _products = new List<Product>
        {
            new Product
            {
                ProductID = 1,
                ProductName = "sdfsd1",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 2,
                ProductName = "sdfsd2",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 3,
                ProductName = "sdfsd3",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 4,
                ProductName = "sdfsd1",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 5,
                ProductName = "sdfsd2",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 6,
                ProductName = "sdfsd3",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 7,
                ProductName = "sdfsd1",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 8,
                ProductName = "sdfsd2",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 9,
                ProductName = "sdfsd3",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 10,
                ProductName = "sdfsd3",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },

            new Product
            {
                ProductID = 11,
                ProductName = "sdfsd1",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 12,
                ProductName = "sdfsd2",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 13,
                ProductName = "sdfsd3",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 14,
                ProductName = "sdfsd1",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 15,
                ProductName = "sdfsd2",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 16,
                ProductName = "sdfsd3",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 17,
                ProductName = "sdfsd1",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 18,
                ProductName = "sdfsd2",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 19,
                ProductName = "sdfsd3",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 20,
                ProductName = "sdfsd3",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },

            new Product
            {
                ProductID = 21,
                ProductName = "sdfsd1",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 22,
                ProductName = "sdfsd2",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 23,
                ProductName = "sdfsd3",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 24,
                ProductName = "sdfsd1",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 25,
                ProductName = "sdfsd2",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 26,
                ProductName = "sdfsd3",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 27,
                ProductName = "sdfsd1",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 28,
                ProductName = "sdfsd2",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 29,
                ProductName = "sdfsd3",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 30,
                ProductName = "sdfsd1",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },

            new Product
            {
                ProductID = 31,
                ProductName = "sdfsd1",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 32,
                ProductName = "sdfsd2",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 33,
                ProductName = "sdfsd3",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 34,
                ProductName = "sdfsd1",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 35,
                ProductName = "sdfsd2",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 36,
                ProductName = "sdfsd3",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 37,
                ProductName = "sdfsd1",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 38,
                ProductName = "sdfsd2",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
            new Product
            {
                ProductID = 39,
                ProductName = "sdfsd3",
                Discontinued = false,
                UnitsInStock = 234,
                UnitPrice = 3244
            },
        };

        //public ProductsController(SampleContext context)
        //{
        //    _context = context;
        //}

        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public bool Discontinued { get; set; }
            public int UnitsInStock { get; set; }
            public int UnitPrice { get; set; }
        }

        [HttpGet]
        public DataSourceResult GetProducts([DataSourceRequest]DataSourceRequest request)
        {
            return _products.ToDataSourceResult(request);
        }

        [HttpPost]
        public IEnumerable<Product> CreateProducts([FromBody]IEnumerable<Product> models)
        {
            return models;
        }

        [HttpPut]
        public IEnumerable<Product> UpdateProducts([FromBody]IEnumerable<Product> models)
        {
            return models;
        }

        [HttpDelete]
        public IEnumerable<Product> DeleteProducts([FromBody]IEnumerable<Product> models)
        {
            return models;
        }
    }
}
