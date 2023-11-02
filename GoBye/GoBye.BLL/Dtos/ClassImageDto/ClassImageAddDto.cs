using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Dtos.ClassImageDto
{

    public class ClassImageAddDto
    {
        public int BusClassId { get; set; }
        public string ImageURL { get; set; } = string.Empty;
    }
}
