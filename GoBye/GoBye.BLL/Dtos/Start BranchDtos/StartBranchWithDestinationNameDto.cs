namespace GoBye.BLL.Dtos.StartBranchDtos
{
    public class StartBranchWithDestinationNameDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DestinationName { get; set; } = string.Empty;
    }
}
