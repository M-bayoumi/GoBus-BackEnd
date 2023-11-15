using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.PaymentManagers
{
    public interface IPaymentManager
    {
        Task<Response> CreateOrUpdatePaymentIntent(int reservationId);
    }
}
