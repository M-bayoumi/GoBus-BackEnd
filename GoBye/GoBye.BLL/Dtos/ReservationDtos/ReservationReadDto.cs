using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Dtos.ReservationDtos
{
    public class ReservationReadDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public List<int> SeatNumbers { get; set; } = new List<int>();
    }
}
