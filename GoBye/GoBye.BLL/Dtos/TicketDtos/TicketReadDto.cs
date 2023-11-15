using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Dtos.TicketDtos
{
    public class TicketReadDto
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public int ReservationId { get; set; }
    }
}
