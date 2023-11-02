using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Dtos.ReportDtos
{
    public class ReportDetailsDto
    {
        public int Id { get; set; }
        public int ReservationNumber { get; set; }
        public string Message { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserPhone { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
