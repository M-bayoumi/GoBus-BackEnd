using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.ReportRepo
{
    public class ReportRepo:GenericRepo<Report>, IReportRepo
    {
        private readonly AppDbContext _appDbContext;

        public ReportRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Report>?> GetAllWithUserInfoAsync()
        {
            return await _appDbContext.Reports.Include(x=>x.User).ToListAsync();
        }

        public async Task<Report?> GetByIdWithUserInfoAsync(int id)
        {
            return await _appDbContext.Reports.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
