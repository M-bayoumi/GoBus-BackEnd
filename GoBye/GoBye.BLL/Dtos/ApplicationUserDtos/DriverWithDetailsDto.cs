using GoBye.BLL.Dtos.BusDtos;
using GoBye.DAL.Data.Models;

namespace GoBye.BLL.Dtos.ApplicationUserDtos
{
    public class DriverWithDetailsDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public IEnumerable<BusDetailsDto> busDetailsDtos { get; set; } = new List<BusDetailsDto>();
    }
}
