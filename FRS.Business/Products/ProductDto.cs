namespace FRS.Business.Products
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public bool Discontinued { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitPrice { get; set; }
    }
}
