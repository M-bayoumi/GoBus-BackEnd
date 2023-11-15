using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.ApplicationUserRepo
{
    public class ApplicationUserRepo : IApplicationUserRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserRepo(AppDbContext appDbContext,UserManager<ApplicationUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }
        public async Task<IEnumerable<ApplicationUser>?> GetAllAsync()
        {
            return await _appDbContext
                .ApplicationUsers
                .ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>?> GetAllUsersWithDetailsAsync()
        {
            return await _appDbContext
                .ApplicationUsers

                .Include(user => user.Reservations)
                .ThenInclude(reservation => reservation.Trip)
                .ThenInclude(trip => trip.StartBranch)

                .Include(user => user.Reservations)
                .ThenInclude(reservation => reservation.Trip)
                .ThenInclude(trip => trip.EndBranch)
                
                .Include(user => user.Reservations)
                .ThenInclude(reservation => reservation.Trip)
                .ThenInclude(trip => trip.Bus)
                .ThenInclude(bus => bus.BusClass)

                .Include(x => x.Reports)

                .Where(x=>x.ApplicationUserRoles.Any(y=>y.RoleId == "1837ae0a-7274-4acc-8165-65aced540cd2"))

                .ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>?> GetAllDriversWithDetailsAsync()
        {
            return await _appDbContext
                .ApplicationUsers

                .Include(user => user.Buses)
                .ThenInclude(bus => bus.BusClass)

                .Include(user => user.Buses)
                .ThenInclude(bus => bus.Trips)
                .ThenInclude(trip => trip.StartBranch)

                .Include(user => user.Buses)
                .ThenInclude(bus => bus.Trips)
                .ThenInclude(trip => trip.EndBranch)

                .Include(user => user.Buses)
                .ThenInclude(bus => bus.Trips)
                .ThenInclude(trip => trip.Reservations)
                .ThenInclude(reservation => reservation.User)

                .Include(user => user.Buses)
                .ThenInclude(bus => bus.Trips)
                .ThenInclude(trip => trip.Reservations)
                .ThenInclude(reservation => reservation.Tickets)

                .Where(x => x.ApplicationUserRoles.Any(y => y.RoleId == "491c779b-92be-4a0c-a1bf-91c28fc20e1e"))

                .ToListAsync();
        }


        public async Task<IEnumerable<ApplicationUser>?> GetAllByRoleAsync(string roleId)
        {
            IEnumerable<string> UserIdsByRoleId = _appDbContext
                .UserRoles
                .Where(x => x.RoleId == roleId)
                .Select(x => x.UserId)
                .ToList();

            List<ApplicationUser>? users = new List<ApplicationUser>();

            foreach (var userid in UserIdsByRoleId)
            {
                ApplicationUser? user = await _appDbContext
                    .ApplicationUsers
                    .FirstOrDefaultAsync(x => x.Id == userid);

                if (user is not null)
                {
                    users.Add(user);
                }
            }
            return users;
        }


        public async Task<ApplicationUser?> GetUserByIdWithDetailsAsync(string id)
        {
            return await _appDbContext
                .ApplicationUsers

                .Include(user => user.Reservations)
                .ThenInclude(reservation => reservation.Trip)
                .ThenInclude(trip => trip.StartBranch)

                .Include(user => user.Reservations)
                .ThenInclude(reservation => reservation.Trip)
                .ThenInclude(trip => trip.EndBranch)

                .Include(user => user.Reservations)
                .ThenInclude(reservation => reservation.Trip)
                .ThenInclude(trip => trip.Bus)
                .ThenInclude(bus => bus.BusClass)

                .Include(x => x.Reports)

                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<ApplicationUser?> GetDriverByIdWithDetailsAsync(string id)
        {
            return await _appDbContext
                .ApplicationUsers

                .Include(user => user.Buses)
                .ThenInclude(bus => bus.BusClass)

                .Include(user => user.Buses)
                .ThenInclude(bus => bus.Trips)
                .ThenInclude(trip => trip.StartBranch)

                .Include(user => user.Buses)
                .ThenInclude(bus => bus.Trips)
                .ThenInclude(trip => trip.EndBranch)

                .Include(user => user.Buses)
                .ThenInclude(bus => bus.Trips)
                .ThenInclude(trip => trip.Reservations)
                .ThenInclude(reservation => reservation.User)

                .Include(user => user.Buses)
                .ThenInclude(bus => bus.Trips)
                .ThenInclude(trip => trip.Reservations)
                .ThenInclude(reservation => reservation.Tickets)

                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<ApplicationUser?> GetByIdAsync(string id)
        {
            return await _appDbContext
                .ApplicationUsers
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<IEnumerable<IdentityError>> AddAsync(ApplicationUser applicationUser,string password)
        {
            IdentityResult result = await _userManager.CreateAsync(applicationUser, password);
            return result.Errors;
        }


        public void DeleteAsync(ApplicationUser applicationUser)
        {
            _appDbContext.ApplicationUsers.Remove(applicationUser);
        }
    }
}
