using OnBudget.BL.DTOs.PictureDtos;

namespace OnBudget.BL.DTOs.ProductDtos
{
    public class ReadProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double UnitPrice { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
        public string SupplierHandle { get; set; }
        public List<ReadPictureDto> Pictures { get; set; }


    }
}
