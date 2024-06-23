namespace OnBudget.BL.DTOs.ProductDtos
{
    public class WriteProductDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double UnitPrice { get; set; }
        public string Color { get; set; }
        public string SupplierHandle { get; set; }

        public string CategoryName { get; set; }
    }
}
