namespace GoBye.DAL.Data.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public IEnumerable<PublicActivity> PublicActivities { get; set; } = new List<PublicActivity>();
        public IEnumerable<StartBranch> StartBranchs { get; set; } = new List<StartBranch>();
        public IEnumerable<EndBranch> EndBranchs { get; set; } = new List<EndBranch>();
    }
}
