using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.ClassImageRepo
{
    public class ClassImageRepo:GenericRepo<ClassImage>, IClassImageRepo
    {
        private readonly AppDbContext _appDbContext;

        public ClassImageRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<ClassImage>?> GetAllByBusClassIdAsync(int id)
        {
            return await _appDbContext.ClassImages.Where(x => x.BusClassId == id).ToListAsync();
        }
    }
}
