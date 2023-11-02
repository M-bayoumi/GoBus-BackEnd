namespace GoBye.BLL.Dtos.ReservationDtos
{
    public class ReservationAddDto
    {
        public int Number { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string UserId { get; set; } = string.Empty;
        public int TripId { get; set; }
        public IEnumerable<int> SeatNumbers { get; set; } = new List<int>();
    }
}
