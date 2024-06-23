namespace OnBudget.BL.DTOs.ShipperDtos
{
    public class ReadShipperDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public List<string> Suppliers { get; set; }

    }
}
