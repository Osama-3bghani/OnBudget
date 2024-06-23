using OnBudget.BL.DTOs.ProductDtos;

namespace OnBudget.BL.DTOs.OrderRepo
{
    public class ReadOrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public List<ReadProductDto> Products { get; set; }

    }
}
