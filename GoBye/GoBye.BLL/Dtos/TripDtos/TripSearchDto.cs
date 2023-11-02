namespace GoBye.BLL.Dtos.TripDtos
{
    public class TripSearchDto
    {
        public bool TwoWay { get; set; }
        public int Quantity { get; set; }
        public string DepartureDate { get; set; } = string.Empty;
        public string ReturnDate { get; set; } = string.Empty;
        public int StartBranchId { get; set; }
        public int EndBranchId { get; set; }
    }
}
