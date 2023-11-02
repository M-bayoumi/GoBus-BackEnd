namespace GoBye.DAL.Data.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public decimal Price { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; } = null!;
        public int StartBranchId { get; set; }
        public StartBranch StartBranch { get; set; } = null!;
        public int EndBranchId { get; set; }
        public EndBranch EndBranch { get; set; } = null!;
        public IEnumerable<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
