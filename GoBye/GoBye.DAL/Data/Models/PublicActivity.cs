namespace GoBye.DAL.Data.Models
{
    public class PublicActivity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DestinationID { get; set; }
        public Destination Destination { get; set; } = null!;
    }
}
