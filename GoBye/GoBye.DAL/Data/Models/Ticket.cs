namespace GoBye.DAL.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } = null!;
    }
}
