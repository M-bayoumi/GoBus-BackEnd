using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.EndBranchRepo
{
    public interface IEndBranchRepo:IGenericRepo<EndBranch>
    {
        Task<IEnumerable<EndBranch>?> GetAllByDestinationIdAsync(int id);
        Task<IEnumerable<EndBranch>?> GetAllWithDestinationNameAsync();
        Task<EndBranch?> GetByIdWithDestinationNameAsync(int id);
        Task<IEnumerable<EndBranch>?> FilterEndBranchesByStartBranchDestinationIdAsync(int id);

    }
}
