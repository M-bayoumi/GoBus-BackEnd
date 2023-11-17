using System.ComponentModel.DataAnnotations;

namespace GoBye.DAL.Data.Models
{
    public class Bus
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; } = true;
        public string CurrentBranch { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public int BusClassId { get; set; }
        public BusClass BusClass { get; set; } = null!;
        public string DriverId { get; set; } = string.Empty;
        public ApplicationUser Driver { get; set; } = null!;
        public IEnumerable<Trip> Trips { get; set; } = new List<Trip>();
    }
}
