using GoBye.BLL.Managers.ApplicationRoleManagers;
using GoBye.BLL.Managers.ApplicationUserManager;
using GoBye.BLL.Managers.BusClassManagers;
using GoBye.BLL.Managers.BusManagers;
using GoBye.BLL.Managers.ClassImageManagers;
using GoBye.BLL.Managers.DestinationManagers;
using GoBye.BLL.Managers.EndBranchManagers;
using GoBye.BLL.Managers.PolicyManager;
using GoBye.BLL.Managers.PublicActivityManagers;
using GoBye.BLL.Managers.QuestionManagers;
using GoBye.BLL.Managers.ReportManagers;
using GoBye.BLL.Managers.ReservationManagers;
using GoBye.BLL.Managers.StartBranchManagers;
using GoBye.BLL.Managers.TermManagers;
using GoBye.BLL.Managers.TicketManagers;
using GoBye.BLL.Managers.TripManagers;
using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.ApplicationRoleRepo;
using GoBye.DAL.Repos.ApplicationUserRepo;
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
using GoBye.DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Hangfire;
using GoBye.DAL.Repos.ApplicationUserRoleRepo;
using GoBye.BLL.Managers.ApplicationUserRoleManagers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;
using GoBye.BLL.Managers.PaymentManagers;
using Microsoft.AspNetCore.Http.Features;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Hangfire 
var constr = builder.Configuration.GetConnectionString("constr");
builder.Services.AddHangfire(x => x.UseSqlServerStorage(constr));
builder.Services.AddHangfireServer();
#endregion


#region Default Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Files Service
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = long.MaxValue;
});
#endregion


#region CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllDomains", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
#endregion


#region Repos Services
builder.Services.AddScoped<IApplicationRoleRepo, ApplicationRoleRepo>();
builder.Services.AddScoped<IApplicationUserRepo, ApplicationUserRepo>();
builder.Services.AddScoped < IApplicationUserRoleRepo, ApplicationUserRoleRepo>();
builder.Services.AddScoped<IBusClassRepo, BusClassRepo>();
builder.Services.AddScoped<IBusRepo, BusRepo>();
builder.Services.AddScoped<IClassImageRepo, ClassImageRepo>();
builder.Services.AddScoped<IDestinationRepo, DestinationRepo>();
builder.Services.AddScoped<IEndBranchRepo, EndBranchRepo>();
builder.Services.AddScoped<IPolicyRepo, PolicyRepo>();
builder.Services.AddScoped<IPublicActivityRepo, PublicActivityRepo>();
builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
builder.Services.AddScoped<IReportRepo, ReportRepo>();
builder.Services.AddScoped<IReservationRepo, ReservationRepo>();
builder.Services.AddScoped<IStartBranchRepo, StartBranchRepo>();
builder.Services.AddScoped<ITermRepo, TermRepo>();
builder.Services.AddScoped<ITicketRepo, TicketRepo>();
builder.Services.AddScoped<ITripRepo, TripRepo>();
#endregion


#region Managers
builder.Services.AddScoped<IApplicationUserManager, ApplicationUserManager>();
builder.Services.AddScoped<IApplicationRoleManager, ApplicationRoleManager>();
builder.Services.AddScoped<IApplicationUserRoleManager, ApplicationUserRoleManager>();
builder.Services.AddScoped<IBusClassManager, BusClassManager>();
builder.Services.AddScoped<IBusManager, BusManager>();
builder.Services.AddScoped<IClassImageManager, ClassImageManager>();
builder.Services.AddScoped<IDestinationManager, DestinationManager>();
builder.Services.AddScoped<IEndBranchManager, EndBranchManager>();
builder.Services.AddScoped<IPolicyManager, PolicyManager>();
builder.Services.AddScoped<IPublicActivityManager, PublicActivityManager>();
builder.Services.AddScoped<IQuestionManager, QuestionManager>();
builder.Services.AddScoped<IReportManager, ReportManager>();
builder.Services.AddScoped<IReservationManager, ReservationManager>();
builder.Services.AddScoped<IStartBranchManager, StartBranchManager>();
builder.Services.AddScoped<ITermManager, TermManager>();
builder.Services.AddScoped<ITicketManager, TicketManager>();
builder.Services.AddScoped<ITripManager, TripManager>();
builder.Services.AddScoped<IPaymentManager, PaymentManager>();
#endregion


#region UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion


#region Database
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(constr);
});
#endregion


#region Identity

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
;

#endregion


#region Authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(optione =>
{
    optione.SaveToken = true;
    optione.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!)),
    };
});


#endregion

#region Authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ForUser", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "User");
    });

    options.AddPolicy("ForAdmin", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "Admin");
    });

    options.AddPolicy("ForDriver", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "Driver");
    });
});


#endregion

var app = builder.Build();

#region Middlewares

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();

app.UseHttpsRedirection();

app.UseCors("AllowAllDomains");
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


#endregion

app.Run();
