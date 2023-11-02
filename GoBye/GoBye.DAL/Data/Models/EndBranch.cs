namespace GoBye.DAL.Data.Models
{
    public class EndBranch
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int DestinationId { get; set; }
        public Destination Destination { get; set; } = null!;
        public IEnumerable<Trip> Trips { get; set; } = new List<Trip>();
    }
}
