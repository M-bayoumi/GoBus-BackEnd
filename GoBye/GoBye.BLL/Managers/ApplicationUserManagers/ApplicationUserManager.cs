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

        #region GetAllUsersAsync
        public async Task<Response> GetAllUsersAsync()
        {
            IEnumerable<ApplicationUser>? applicationUsers = await _unitOfWork.ApplicationUserRepo.GetAllUsersAsync();
            if (applicationUsers is not null)
            {
                var data = applicationUsers.Select(x => new UserReadDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName!,
                    Email = x.Email!,
                    PhoneNumber = x.PhoneNumber!,
                    Blocked = x.Blocked
   
                });
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, "There is no Users found");

        }
        #endregion


        #region GetAllDriversAsync
        public async Task<Response> GetAllDriversAsync()
        {
            IEnumerable<ApplicationUser>? applicationUsers = await _unitOfWork.ApplicationUserRepo.GetAllDriversAsync();
            if (applicationUsers is not null)
            {
                var data = applicationUsers.Select(x => new UserReadDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName!,
                    Email = x.Email!,
                    PhoneNumber = x.PhoneNumber!,

                });
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, "There is no Drivers found");

        }
        #endregion


        #region GetAllAdminsAsync
        public async Task<Response> GetAllAdminsAsync()
        {
            IEnumerable<ApplicationUser>? applicationUsers = await _unitOfWork.ApplicationUserRepo.GetAllAdminsAsync();
            if (applicationUsers is not null)
            {
                var data = applicationUsers.Select(x => new UserReadDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName!,
                    Email = x.Email!,
                    PhoneNumber = x.PhoneNumber!,

                });
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, "There is no Admins found");

        }
        #endregion


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
                    Blocked = x.Blocked,
                    ReservationUserDtos = x.Reservations.Select(y => new ReservationUserDto
                    {
                        Id = y.Id,
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
            var role = await _unitOfWork.ApplicationRoleRepo.GetByIdAsync(roleId);
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
            if(role is not null)
            {
                return _unitOfWork.Response(false, null, $"There is no Users found With Role ({role.Name})");
            }
            return _unitOfWork.Response(false, null, "InValid Role");

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
            return _unitOfWork.Response(false, null, $"User not found");

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
                                Quantity =z.Quantity,
                                UserName = z.User.UserName!,
                                PhoneNumber = z.User.PhoneNumber!
                            })

                        })

                    })
                };
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, $"Driver not found");

        }
        #endregion


        #region GetByIdAsync
        public async Task<Response> GetByIdAsync(string id)
        {
            ApplicationUser? applicationUser = await _unitOfWork.ApplicationUserRepo.GetByIdAsync(id);
            if (applicationUser is not null)
            {
                var data = new UserReadDto
                {
                    Id = applicationUser.Id,
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    UserName = applicationUser.UserName!,
                    Email = applicationUser.Email!,
                    PhoneNumber = applicationUser.PhoneNumber!,
                    
                };
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, $"User not found");

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
            return _unitOfWork.Response(false, null, $"User failed to Added");
        }
        #endregion


        #region RegisterDriverAsync
        public async Task<Response> RegisterDriverAsync(RegisterDto registerDto)
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
            if (!errors.Any())
            {
                ApplicationRole? applicationRole = await _unitOfWork.ApplicationRoleRepo.GetByIdAsync("491c779b-92be-4a0c-a1bf-91c28fc20e1e");

                if (applicationUser is not null && applicationRole is not null)
                {
                    ApplicationUserRole applicationUserRole = new ApplicationUserRole
                    {
                        ApplicationRole = applicationRole,
                        ApplicationUser = applicationUser
                    };
                    await _unitOfWork.ApplicationUserRoleRepo.AddAsync(applicationUserRole);
                    bool ressult = await _unitOfWork.SaveChangesAsync() > 0;
                    if (ressult)
                    {
                        return _unitOfWork.Response(true, null, $"Driver has been assignd to Role ({applicationRole.Name})");
                    }
                    return _unitOfWork.Response(true, null, $"Driver has been Added but dosen't assignd to Role ({applicationRole.Name})");
                }

            }
            return _unitOfWork.Response(false, null, $"Driver failed to Added");
        }
        #endregion


        #region RegisterAdminAsync
        public async Task<Response> RegisterAdminAsync(RegisterDto registerDto)
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
            if (!errors.Any())
            {
                ApplicationRole? applicationRole = await _unitOfWork.ApplicationRoleRepo.GetByIdAsync("b79f5098-1212-492e-853b-0ea294f0ec2d");

                if (applicationUser is not null && applicationRole is not null)
                {
                    ApplicationUserRole applicationUserRole = new ApplicationUserRole
                    {
                        ApplicationRole = applicationRole,
                        ApplicationUser = applicationUser
                    };
                    await _unitOfWork.ApplicationUserRoleRepo.AddAsync(applicationUserRole);
                    bool ressult = await _unitOfWork.SaveChangesAsync() > 0;
                    if (ressult)
                    {
                        return _unitOfWork.Response(true, null, $"Admin has been assignd to Role ({applicationRole.Name})");
                    }
                    return _unitOfWork.Response(true, null, $"Admin has been Added but dosen't assignd to Role ({applicationRole.Name})");
                }

            }
            return _unitOfWork.Response(false, null, $"Driver failed to Added");
        }
        #endregion


        #region GetAllUserNamesAsync
        public async Task<Response> GetAllUserNamesAsync()
        {
            IEnumerable<ApplicationUser>? applicationUsers = await _unitOfWork.ApplicationUserRepo.GetAllAsync();

            if(applicationUsers is not null)
            {
                var data = applicationUsers.Select(x=>x.UserName).ToList();
                return _unitOfWork.Response(true, data, null);
            }
            return _unitOfWork.Response(false, null, $"there is no usernames");

        }
        #endregion


        #region GetAllEmailsAsync
        public async Task<Response> GetAllEmailsAsync()
        {
            IEnumerable<ApplicationUser>? applicationUsers = await _unitOfWork.ApplicationUserRepo.GetAllAsync();

            if (applicationUsers is not null)
            {
                var data = applicationUsers.Select(x => x.Email).ToList();
                return _unitOfWork.Response(true, data, null);
            }
            return _unitOfWork.Response(false, null, $"there is no emails");

        }
        #endregion


        #region BlockUserAsync
        public async Task<Response> BlockUserAsync(string id)
        {
            ApplicationUser? applicationUser = await _unitOfWork.ApplicationUserRepo.GetByIdAsync(id);
            if (applicationUser is not null)
            {
                bool ressult;
                if (applicationUser.Blocked == true)
                {
                    applicationUser.Blocked = false;
                    ressult = await _unitOfWork.SaveChangesAsync() > 0;

                }
                else
                {
                    applicationUser.Blocked = true;
                     ressult = await _unitOfWork.SaveChangesAsync() > 0;

                }

                if (ressult && applicationUser.Blocked)
                {
                    return _unitOfWork.Response(true, null, $"User has been blocked successfully");
                }
                else
                {
                    return _unitOfWork.Response(true, null, $"User has been unBlocked successfully");
                }

            }
            return _unitOfWork.Response(false, null, $"User not found");
        }
        #endregion


        #region LoginAsync
        public async Task<Response> LoginAsync(LoginDto loginDto)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user is not null && !user.Blocked)
            {
                var roles = await _userManager.GetRolesAsync(user);
                bool found = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (found && roles.Contains(loginDto.Role))
                {
                    var claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Name, user.UserName!));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
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
                        expires: loginDto.RememberMe? DateTime.Now.AddDays(15):DateTime.Now.AddMinutes(20),
                        signingCredentials: signingCred
                        );

                    return _unitOfWork.Response(true, new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                            expiration = jwtSecurityToken.ValidTo,
                            roles = roles
                        },
                        $"{user.Email} is authorized");

                }
            }
            else if (user is not null && user.Blocked)
            {
                return _unitOfWork.Response(false, null, $"User is blocked");

            }
            return _unitOfWork.Response(false, null, $"Email or password is not valid");
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
            return _unitOfWork.Response(false, null, $"User not found");
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
            return _unitOfWork.Response(false, null, $"User not found");
        }
        #endregion
    }
}
