using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.ApplicationRoleRepo
{
    public interface IApplicationRoleRepo:IGenericRepo<ApplicationRole>
    {
        Task<ApplicationRole?> GetByIdAsync(string id);
    }
}
