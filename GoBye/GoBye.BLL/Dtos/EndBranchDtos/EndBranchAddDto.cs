namespace GoBye.BLL.Dtos.EndBranchDtos
{
    public class EndBranchAddDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int DestinationId { get; set; }
    }
}
