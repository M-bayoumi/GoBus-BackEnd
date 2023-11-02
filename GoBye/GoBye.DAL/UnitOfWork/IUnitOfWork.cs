using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.ApplicationRoleRepo;
using GoBye.DAL.Repos.ApplicationUserRepo;
using GoBye.DAL.Repos.ApplicationUserRoleRepo;
using GoBye.DAL.Repos.BusRepo;
using GoBye.DAL.Repos.ClassBusRepo;
using GoBye.DAL.Repos.ClassImageRepo;
using GoBye.DAL.Repos.DestinationRepo;
using GoBye.DAL.Repos.EndBranchRepo;
using GoBye.DAL.Repos.PolicyRepo;
using GoBye.DAL.Repos.PublicActivityRepo;
using GoBye.DAL.Repos.QuestionRepo;
using GoBye.DAL.Repos.ReportRepo;
using GoBye.DAL.Repos.ReservationRepo;
using GoBye.DAL.Repos.StartBranchRepo;
using GoBye.DAL.Repos.TermRepo;
using GoBye.DAL.Repos.TicketRepo;
using GoBye.DAL.Repos.TripRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IApplicationRoleRepo ApplicationRoleRepo { get; }
        public IApplicationUserRepo ApplicationUserRepo { get; }
        public IApplicationUserRoleRepo ApplicationUserRoleRepo { get; }
        public IBusClassRepo BusClassRepo { get; }
        public IBusRepo BusRepo { get; }
        public IClassImageRepo ClassImageRepo { get; }
        public IDestinationRepo DestinationRepo { get; }
        public IEndBranchRepo EndBranchRepo { get; }
        public IPolicyRepo PolicyRepo { get; }
        public IPublicActivityRepo PublicActivityRepo { get; }
        public IQuestionRepo QuestionRepo { get; }
        public IReportRepo ReportRepo { get; }
        public IReservationRepo ReservationRepo { get; }
        public IStartBranchRepo StartBranchRepo { get; }
        public ITermRepo TermRepo { get; }
        public ITicketRepo TicketRepo { get; }
        public ITripRepo TripRepo { get; }

        Task<int> SaveChangesAsync();
        Response Response(bool success, object? data, object? messages);
    }
}
