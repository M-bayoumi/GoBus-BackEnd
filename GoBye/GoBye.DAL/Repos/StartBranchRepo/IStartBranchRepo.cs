using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.StartBranchRepo
{
    public interface IStartBranchRepo:IGenericRepo<StartBranch>
    {
        Task<IEnumerable<StartBranch>?> GetAllByDestinationIdAsync(int id);
        Task<IEnumerable<StartBranch>?> GetAllWithDestinationNameAsync();
        Task<StartBranch?> GetByIdWithDestinationNameAsync(int id);
    }
}
