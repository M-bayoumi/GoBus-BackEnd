using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.PublicActivityRepo
{
    public interface IPublicActivityRepo:IGenericRepo<PublicActivity>
    {
        Task<IEnumerable<PublicActivity>?> GetAllByDestinationIdAsync(int id);
    }
}
