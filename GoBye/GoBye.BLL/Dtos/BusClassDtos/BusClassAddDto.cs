using GoBye.DAL.Data.Models;

namespace GoBye.BLL.Dtos.BusClassDtos
{
    public class BusClassAddDto
    {
        public string Name { get; set; } = string.Empty;
        public string AveragePrice { get; set; } = string.Empty;
        public List<string> ClassImageURLs { get; set; } = new List<string>();
    }
}
