namespace GoBye.BLL.Dtos.BusDtos
{
    public class BusAvailableDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool Available { get; set; }
        public string CurrentBranch { get; set; } = string.Empty;
        public string ClassBusName { get; set; } = string.Empty;
    }
}
