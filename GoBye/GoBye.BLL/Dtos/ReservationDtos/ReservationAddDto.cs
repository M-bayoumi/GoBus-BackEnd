namespace GoBye.BLL.Dtos.ReservationDtos
{
    public class ReservationAddDto
    {
        public int Quantity { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int TripId { get; set; }
        public IEnumerable<int> SeatNumbers { get; set; } = new List<int>();
    }
}
