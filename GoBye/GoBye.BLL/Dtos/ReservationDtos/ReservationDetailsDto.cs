namespace GoBye.BLL.Dtos.ReservationDtos
{
    public class ReservationDetailsDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int TripId { get; set; } 
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<int> SeatNumbers { get; set; } = new List<int>();
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string BusClassName { get; set; } = string.Empty;
        public int BusNumber { get; set; }
        public string StartBranchName { get; set; } = string.Empty;
        public string EndBranchName { get; set; } = string.Empty;
    }
}
