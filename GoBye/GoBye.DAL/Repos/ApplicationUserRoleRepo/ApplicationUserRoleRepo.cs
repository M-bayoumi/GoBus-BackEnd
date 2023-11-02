using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GoBye.DAL.Repos.ApplicationUserRoleRepo
{
    public class ApplicationUserRoleRepo : GenericRepo<ApplicationUserRole>, IApplicationUserRoleRepo
    {
        private readonly AppDbContext _appDbContext;

        public ApplicationUserRoleRepo(AppDbContext appDbContext):base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ApplicationUserRole?> GetByUserIdAsync(string userId)
        {
            return await _appDbContext
                .ApplicationUserRoles

                .FirstOrDefaultAsync(x => x.ApplicationUser.Id == userId);
        }
    }
}
