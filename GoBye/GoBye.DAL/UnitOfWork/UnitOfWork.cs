using GoBye.DAL.Data.Context;
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
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
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
        public AppDbContext AppDbContext { get; }

        public UnitOfWork(AppDbContext appDbContext,
            IApplicationRoleRepo applicationRoleRepo,
            IApplicationUserRepo applicationUserRepo,
            IApplicationUserRoleRepo applicationUserRoleRepo,
            IBusClassRepo busClassRepo,
            IBusRepo busRepo,
            IClassImageRepo classImageRepo,
            IDestinationRepo destinationRepo,
            IEndBranchRepo endBranchRepo,
            IPolicyRepo policyRepo,
            IPublicActivityRepo publicActivityRepo,
            IQuestionRepo questionRepo,
            IReportRepo reportRepo,
            IReservationRepo reservationRepo,
            IStartBranchRepo startBranchRepo,
            ITermRepo termRepo,
            ITicketRepo ticketRepo,
            ITripRepo tripRepo)
        {
            AppDbContext = appDbContext;
            ApplicationRoleRepo = applicationRoleRepo;
            ApplicationUserRepo = applicationUserRepo;
            ApplicationUserRoleRepo = applicationUserRoleRepo;
            BusClassRepo = busClassRepo;
            BusRepo = busRepo;
            ClassImageRepo = classImageRepo;
            DestinationRepo = destinationRepo;
            EndBranchRepo = endBranchRepo;
            PolicyRepo = policyRepo;
            PublicActivityRepo = publicActivityRepo;
            QuestionRepo = questionRepo;
            ReportRepo = reportRepo;
            ReservationRepo = reservationRepo;
            StartBranchRepo = startBranchRepo;
            TermRepo = termRepo;
            TicketRepo = ticketRepo;
            TripRepo = tripRepo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await AppDbContext.SaveChangesAsync();
        }

        public Response Response(bool success, object? data, object? messages)
        {
            return new Response
            {
                Success = success,
                Data = data,
                Messages = messages
            };
        }
    }
}
