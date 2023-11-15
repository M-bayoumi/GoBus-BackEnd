using GoBye.BLL.Dtos.ReservationDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.PaymentManagers
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public PaymentManager(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<Response> CreateOrUpdatePaymentIntent(int reservationId)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:Secretkey"];
            Reservation? reservation = await _unitOfWork.ReservationRepo.GetByIdWithTripDetailsAsync(reservationId);
            if (reservation is not null)
            {
                var data = new ReservationPaymentDto
                {
                    Id = reservation.Id,
                    Price = reservation.Price,
                    Quantity = reservation.Quantity,
                    TotalPrice = reservation.TotalPrice,
                    Date = reservation.Date,
                    UserId = reservation.UserId,
                    UserName = reservation.User.UserName!,
                    SeatNumbers = reservation.Tickets.Select(x => x.SeatNumber).ToList(),
                    DepartureDate = reservation.Trip.DepartureDate,
                    ArrivalDate = reservation.Trip.ArrivalDate,
                    BusClassName = reservation.Trip.Bus.BusClass.Name,
                    StartBranchName = reservation.Trip.StartBranch.Name,
                    EndBranchName = reservation.Trip.EndBranch.Name,
                };
                var service = new PaymentIntentService();

                PaymentIntent intent;
                if (string.IsNullOrEmpty(reservation?.PaymentIntentId))
                {

                    var options = new PaymentIntentCreateOptions
                    {
                        Amount = (long)reservation!.TotalPrice,
                        Currency ="usd",
                        PaymentMethodTypes= new List<string> { "card"}
                    };
                    intent = await service.CreateAsync(options);

                    reservation.PaymentIntentId = intent.Id;
                    reservation.ClientSecret = intent.ClientSecret;

                    data.PaymentIntentId = intent.Id;
                    data.ClientSecret = intent.ClientSecret;

                    await _unitOfWork.SaveChangesAsync();
                    return _unitOfWork.Response(true, data, $"Payment Created");

                }
                else
                {
                    var options = new PaymentIntentUpdateOptions
                    {
                        Amount = (long)reservation!.TotalPrice,
                    };
                    await service.UpdateAsync(reservation.PaymentIntentId, options);

                    await _unitOfWork.SaveChangesAsync();
                    return _unitOfWork.Response(true, data, $"Payment Updated");
                }
            }

            return _unitOfWork.Response(false, null, $"Payment Failed");
        }
    }
}
