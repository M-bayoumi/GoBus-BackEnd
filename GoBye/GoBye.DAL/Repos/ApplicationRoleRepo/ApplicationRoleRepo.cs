using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.ApplicationRoleRepo
{
    public class ApplicationRoleRepo: GenericRepo<ApplicationRole>, IApplicationRoleRepo
    {
        private readonly AppDbContext _appDbContext;

        public ApplicationRoleRepo(AppDbContext appDbContext):base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ApplicationRole?> GetByIdAsync(string id)
        {
            return await _appDbContext.Set<ApplicationRole>().FindAsync(id);
        }

    }
}
