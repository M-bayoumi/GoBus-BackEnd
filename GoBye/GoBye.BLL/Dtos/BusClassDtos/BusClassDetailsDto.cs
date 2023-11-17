namespace GoBye.BLL.Dtos.BusClassDtos
{
    public class BusClassDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AveragePrice { get; set; } = string.Empty;
        public IEnumerable<int> BusesNumbers { get; set; } = new List<int>();
        public IEnumerable<string> ClassImageURLs { get; set; } = new List<string>();
    }
}
