namespace GoBye.BLL.Dtos.BusDtos
{
    public class BusUpdateDto
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }
        public string CurrentBranch { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public int BusClassId { get; set; }
        public string DriverId { get; set; } = string.Empty;

    }
}
