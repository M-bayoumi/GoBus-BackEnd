namespace GoBye.DAL.Data.Models
{
    public class BusClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Bus> Buses { get; set; } = new List<Bus>();
        public IEnumerable<ClassImage> ClassImages { get; set; } = new List<ClassImage>();
    }
}
