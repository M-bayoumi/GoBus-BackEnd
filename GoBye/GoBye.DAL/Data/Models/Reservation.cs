namespace GoBye.DAL.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = null!; 
        public int TripId { get; set; }
        public Trip Trip { get; set; } = null!;
        public IEnumerable<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
