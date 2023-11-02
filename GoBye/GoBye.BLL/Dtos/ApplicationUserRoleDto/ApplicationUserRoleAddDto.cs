using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Dtos.ApplicationUserRoleDto
{
    public class ApplicationUserRoleAddDto
    {
        public string UserId { get; set; } = null!;
        public string RoleId { get; set; } = null!;
    }
}
