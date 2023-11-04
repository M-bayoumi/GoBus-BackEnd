using GoBye.BLL.Dtos.EndBranchDtos;

namespace GoBye.BLL.Dtos.DestinationDtos
{
    public class DestinationWithBranchesDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<EndBranchReadDto> Branches { get; set; } = new List<EndBranchReadDto>();
    }
}
