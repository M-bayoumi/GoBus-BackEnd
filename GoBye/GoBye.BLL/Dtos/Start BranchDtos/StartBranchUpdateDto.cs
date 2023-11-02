namespace GoBye.BLL.Dtos.StartBranchDtos
{
    public class StartBranchUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int DestinationId { get; set; }
    }
}
