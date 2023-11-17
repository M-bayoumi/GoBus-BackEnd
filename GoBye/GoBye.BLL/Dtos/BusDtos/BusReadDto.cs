using GoBye.BLL.Dtos.ReservationDtos;
using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Dtos.BusDtos
{
    public class BusReadDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }
        public string CurrentBranch { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public int ClassBusId { get; set; } 
        public string ClassBusName { get; set; } = string.Empty;
        public string DriverId { get; set; } = string.Empty;
        public string DriverFirstName { get; set; } = string.Empty;
        public string DriverLastName { get; set; } = string.Empty;
        public int NoOfTrips { get; set; }
    }
}
