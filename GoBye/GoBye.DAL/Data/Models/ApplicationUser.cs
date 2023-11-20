using Microsoft.AspNetCore.Identity;

namespace GoBye.DAL.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool Blocked { get; set; } = false;
        public IEnumerable<ApplicationUserRole> ApplicationUserRoles { get; set; } = new List<ApplicationUserRole>();
        public IEnumerable<Bus> Buses { get; set; } = new List<Bus>();
        public IEnumerable<Reservation> Reservations { get; set; } = new List<Reservation>();
        public IEnumerable<Report> Reports { get; set; } = new List<Report>();
    }

}
