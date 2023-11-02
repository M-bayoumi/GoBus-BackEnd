using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Dtos.BusClassDtos
{
    public class BusClassReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
