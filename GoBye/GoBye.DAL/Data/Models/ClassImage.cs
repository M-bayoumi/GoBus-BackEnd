namespace GoBye.DAL.Data.Models
{
    public class ClassImage
    {
        public int Id { get; set; }
        public int BusClassId { get; set; }
        public string ImageURL { get; set; } = string.Empty;
        public BusClass BusClass { get; set; } = null!;

    }
}
