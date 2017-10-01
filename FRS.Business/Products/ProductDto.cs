using AutoMapper;
using FRS.Common.Contracts;
using FRS.DataModel.Entities;

namespace FRS.Business.Products
{
    public class ProductDto : /*IMapsFrom<Product>,*/ IHasCustomMapping
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public bool Discontinued { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitPrice { get; set; }

        public void ConfigureMapping(IProfileExpression config)
        {
            config.CreateMap<Product, ProductDto>()
                .ForMember(e => e.ProductId, opt => opt.MapFrom(d => d.Id))
                .ReverseMap();
        }
    }
}
