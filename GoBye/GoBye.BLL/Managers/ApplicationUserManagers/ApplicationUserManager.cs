using GoBye.BLL.Dtos.ApplicationUserDtos;
using GoBye.BLL.Dtos.ApplicationUserRoleDto;
using GoBye.BLL.Dtos.BusDtos;
using GoBye.BLL.Dtos.ReportDtos;
using GoBye.BLL.Dtos.ReservationDtos;
using GoBye.BLL.Dtos.TripDtos;
using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GoBye.BLL.Managers.ApplicationUserManager
{
    public class ApplicationUserManager:IApplicationUserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public ApplicationUserManager(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _configuration = configuration;
        }

        #region GetAllUsersWithDetailsAsync
        public async Task<Response> GetAllUsersWithDetailsAsync()
        {
            IEnumerable<ApplicationUser>? applicationUsers = await _unitOfWork.ApplicationUserRepo.GetAllUsersWithDetailsAsync();
            if (applicationUsers is not null)
            {
                var data = applicationUsers.Select(x => new UserWithDetailsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName!,
                    Email = x.Email!,
                    PhoneNumber = x.PhoneNumber!,
                    ReservationUserDtos = x.Reservations.Select(y => new ReservationUserDto
                    {
                        Id = y.Id,
                        Number = y.Number,
                        Quantity = y.Quantity,
                        TotalPrice = y.TotalPrice,
                        Date = y.Date,
                        SeatNumbers = y.Tickets.Select(z => z.SeatNumber).ToList(),
                        DepartureDate = y.Trip.DepartureDate,
                        ArrivalDate = y.Trip.ArrivalDate,
                        BusClassName = y.Trip.Bus.BusClass.Name,
                        StartBranchName = y.Trip.StartBranch.Name,
                        EndBranchName = y.Trip.EndBranch.Name,
                    }),
                    ReportUserDtos = x.Reports.Select(y => new ReportUserDto
                    {
                        Id = y.Id,
                        ReservationNumber = y.ReservationNumber,
                        MessageTitle = y.MessageTitle,
                        MessageContent = y.MessageContent,
                    })
                });
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, "There is no Users found");

        }
        #endregion


        #region GetAllDriversWithDetailsAsync
        public async Task<Response> GetAllDriversWithDetailsAsync()
        {
            IEnumerable<ApplicationUser>? applicationUsers = await _unitOfWork.ApplicationUserRepo.GetAllDriversWithDetailsAsync();
            if(applicationUsers is not null)
            {
                var data = applicationUsers.Select(x => new DriverWithDetailsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName!,
                    Email = x.Email!,
                    PhoneNumber = x.PhoneNumber!,
                    busDetailsDtos = x.Buses.Select(x => new BusDetailsDto
                    {
                        Id = x.Id,
                        Number = x.Number,
                        Capacity = x.Capacity,
                        Available = x.Available,
                        CurrentBranch = x.CurrentBranch,
                        Model = x.Model,
                        Year = x.Year,
                        ClassBusName = x.BusClass.Name,
                        tripDetailsDtos = x.Trips.Select(y => new TripDetailsDto
                        {
                            Id = y.Id,
                            AvailableSeats = y.AvailableSeats,
                            DepartureDate = y.DepartureDate,
                            ArrivalDate = y.ArrivalDate,
                            StartBranchName = y.StartBranch.Name,
                            EndBranchName = y.EndBranch.Name,
                            Price = y.Price,
                            ReservationReadDtos = y.Reservations.Select(z => new ReservationReadDto
                            {
                                Id = z.Id,
                                Number = z.Number,
                                Quantity = z.Quantity,
                                UserName = z.User.UserName!,
                                PhoneNumber = z.User.PhoneNumber!,
                                SeatNumbers = z.Tickets.Select(w=>w.SeatNumber).ToList()
                                
                            })

                        })

                    })
                });
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, "There is no Drivers found");

        }
        #endregion


        #region GetAllByRoleAsync
        public async Task<Response> GetAllByRoleAsync(string roleId)
        {
            IEnumerable<ApplicationUser>? applicationUsers = await _unitOfWork.ApplicationUserRepo.GetAllByRoleAsync(roleId);
            if (applicationUsers is not null)
            {
                var data = applicationUsers.Select(x => new UserReadDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName!,
                    Email = x.Email!,
                    PhoneNumber = x.PhoneNumber!,
                });
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, $"There is no Users found With RoleId ({roleId})");

        }
        #endregion


        #region GetUserByIdWithDetailsAsync
        public async Task<Response> GetUserByIdWithDetailsAsync(string id)
        {
            ApplicationUser? applicationUser = await _unitOfWork.ApplicationUserRepo.GetUserByIdWithDetailsAsync(id);
            if (applicationUser is not null)
            {
                var data = new UserWithDetailsDto
                {
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    UserName = applicationUser.UserName!,
                    Email = applicationUser.Email!,
                    PhoneNumber = applicationUser.PhoneNumber!,
                    ReservationUserDtos = applicationUser.Reservations.Select(y => new ReservationUserDto
                    {
                        Id = y.Id,
                        Number = y.Number,
                        Quantity = y.Quantity,
                        TotalPrice = y.TotalPrice,
                        Date = y.Date,
                        SeatNumbers = y.Tickets.Select(z => z.SeatNumber).ToList(),
                        DepartureDate = y.Trip.DepartureDate,
                        ArrivalDate = y.Trip.ArrivalDate,
                        BusClassName = y.Trip.Bus.BusClass.Name,
                        StartBranchName = y.Trip.StartBranch.Name,
                        EndBranchName = y.Trip.EndBranch.Name,
                    }),
                    ReportUserDtos = applicationUser.Reports.Select(y => new ReportUserDto
                    {
                        Id = y.Id,
                        ReservationNumber = y.ReservationNumber,
                        MessageTitle = y.MessageTitle,
                        MessageContent = y.MessageContent,
                    })
                };
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, $"User with Id ({id}) not found");

        }
        #endregion


        #region GetDriverByIdWithDetailsAsync
        public async Task<Response> GetDriverByIdWithDetailsAsync(string id)
        {
            ApplicationUser? applicationUser = await _unitOfWork.ApplicationUserRepo.GetDriverByIdWithDetailsAsync(id);
            if (applicationUser is not null)
            {
                var data = new DriverWithDetailsDto
                {
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    UserName = applicationUser.UserName!,
                    Email = applicationUser.Email!,
                    PhoneNumber = applicationUser.PhoneNumber!,
                    busDetailsDtos = applicationUser.Buses.Select(x=> new BusDetailsDto
                    {
                        Id = x.Id,
                        Number = x.Number,
                        Capacity = x.Capacity,
                        Available = x.Available,
                        CurrentBranch = x.CurrentBranch,
                        Model = x.Model,
                        Year = x.Year,
                        ClassBusName = x.BusClass.Name,
                        tripDetailsDtos = x.Trips.Select(y=> new TripDetailsDto
                        {
                            Id=y.Id,
                            AvailableSeats = y.AvailableSeats,
                            DepartureDate = y.DepartureDate,
                            ArrivalDate = y.ArrivalDate,
                            StartBranchName = y.StartBranch.Name,
                            EndBranchName = y.EndBranch.Name,
                            Price = y.Price,
                            ReservationReadDtos = y.Reservations.Select(z=> new ReservationReadDto
                            {
                                Id= z.Id,
                                Number =z.Number,
                                Quantity =z.Quantity,
                                UserName = z.User.UserName!,
                                PhoneNumber = z.User.PhoneNumber!
                            })

                        })

                    })
                };
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, $"Driver with Id ({id}) not found");

        }
        #endregion


        #region GetByIdAsync xxx
        public async Task<Response> GetByIdAsync(string id)
        {
            ApplicationUser? applicationUser = await _unitOfWork.ApplicationUserRepo.GetByIdAsync(id);
            if (applicationUser is not null)
            {
                var data = new UserReadDto
                {
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    UserName = applicationUser.UserName!,
                    Email = applicationUser.Email!,
                    PhoneNumber = applicationUser.PhoneNumber!,
                    
                };
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, $"User with Id ({id}) not found");

        }
        #endregion


        #region AddAsync
        public async Task<Response> AddAsync(RegisterDto registerDto)
        {
            ApplicationUser user = new ApplicationUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
            };

            IEnumerable<IdentityError> errors = await _unitOfWork.ApplicationUserRepo.AddAsync(user, registerDto.Password);
            if(!errors.Any())
            {
                return _unitOfWork.Response(true, null, $"UserName with Id ({user.Id}) has been Added");

            }

            return _unitOfWork.Response(false, null, errors);
        }
        #endregion


        #region RegisterAsync
        public async Task<Response> RegisterAsync(RegisterDto registerDto)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
            };

            IEnumerable<IdentityError> errors = await _unitOfWork.ApplicationUserRepo.AddAsync(applicationUser, registerDto.Password);
            if(!errors.Any())
            {
                ApplicationRole? applicationRole = await _unitOfWork.ApplicationRoleRepo.GetByIdAsync("1837ae0a-7274-4acc-8165-65aced540cd2");

                if (applicationUser is not null && applicationRole is not null)
                {
                    ApplicationUserRole applicationUserRole = new ApplicationUserRole
                    {
                        ApplicationRole = applicationRole,
                        ApplicationUser = applicationUser
                    };
                    await _unitOfWork.ApplicationUserRoleRepo.AddAsync(applicationUserRole);
                    bool ressult =  await _unitOfWork.SaveChangesAsync() > 0;
                    if (ressult)
                    {
                        return _unitOfWork.Response(true, null, $"UserName with Id ({applicationUser.Id}) has been assignd to Role ({applicationRole.Name})");
                    }
                    return _unitOfWork.Response(true, null, $"UserName with Id ({applicationUser.Id}) has been Added but dosen't assignd to Role ({applicationRole.Name})");
                }

            }
            return _unitOfWork.Response(false, null, $"UserName with Id ({applicationUser!.Id}) failed to Added");
        }
        #endregion

        #region CheckUserNameAsync
        public async Task<Response> CheckUserNameAsync(string userName)
        {
            ApplicationUser? user = await _userManager.FindByNameAsync(userName);
            if(user is not null)
            {
                return _unitOfWork.Response(false, null, $"UserName ({userName}) is already token");
            }
            return _unitOfWork.Response(true, null, $"UserName ({userName}) is valid");

        }
        #endregion

        #region CheckEmailAsync
        public async Task<Response> CheckEmailAsync(string email)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(email);
            if (user is not null)
            {
                return _unitOfWork.Response(false, null, $"Email ({email}) is already token");
            }
            return _unitOfWork.Response(true, null, $"Email ({email}) is valid");

        }
        #endregion

        #region LoginAsync
        public async Task<Response> LoginAsync(LoginDto loginDto)
        {
            ApplicationUser? user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user is not null)
            {
                bool found = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (found)
                {
                    var claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Name, user.UserName!));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    var roles = await _userManager.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }


                    SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));

                    SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    JwtSecurityToken jwtSecurityToken =
                        new JwtSecurityToken
                        (
                        issuer: _configuration["JWT:Issuer"],
                        audience: _configuration["JWT:Audience"],
                        claims: claims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: signingCred
                        );

                    return _unitOfWork.Response(true, new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                            expiration = jwtSecurityToken.ValidTo
                        },
                        $"{user.UserName} is authorized");

                }
            }
            return _unitOfWork.Response(false, null, $"{user!.UserName} is not authorized");

        }
        #endregion


        #region UpdateAsync
        public async Task<Response> UpdateAsync(string id, UserUpdateDto userUpdateDto)
        {
            ApplicationUser? applicationUser = await _unitOfWork.ApplicationUserRepo.GetByIdAsync(id);
            if(applicationUser is not null)
            {
                applicationUser.FirstName = userUpdateDto.FirstName;
                applicationUser.LastName = userUpdateDto.LastName;
                applicationUser.UserName = userUpdateDto.UserName;
                applicationUser.Email = userUpdateDto.Email;
                applicationUser.PhoneNumber = userUpdateDto.PhoneNumber;

                bool ressult = await _unitOfWork.SaveChangesAsync() > 0;
                if (ressult)
                {
                    return _unitOfWork.Response(true, null, $"UserName with Id ({applicationUser.Id}) has been updated successfully");
                }

            }
            return _unitOfWork.Response(false, null, $"{applicationUser!.UserName} with Id ({id}) not found");
        }
        #endregion


        #region DeleteAsync
        public async Task<Response> DeleteAsync(string id)
        {
            ApplicationUser? applicationUser = await _unitOfWork.ApplicationUserRepo.GetByIdAsync(id);
            if(applicationUser is not null)
            {
                _unitOfWork.ApplicationUserRepo.DeleteAsync(applicationUser);
                bool result = await _unitOfWork.SaveChangesAsync() > 0;
                if (result)
                {
                    return _unitOfWork.Response(true, null, $"The User with id ({id}) has been deleted successfully");
                }
                return _unitOfWork.Response(false, null, $"Failed to delete User with id ({id})");
            }
            return _unitOfWork.Response(false, null, $"User with id ({id}) is not found");
        }
        #endregion
    }
}
