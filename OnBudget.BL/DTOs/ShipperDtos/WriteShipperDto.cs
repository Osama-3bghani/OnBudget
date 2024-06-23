namespace OnBudget.BL.DTOs.ShipperDtos
{
    public class WriteShipperDto
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public List<string> Suppliers { get; set; }

    }
}
