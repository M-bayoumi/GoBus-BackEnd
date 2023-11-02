using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Dtos.QuestionDtos
{
    public class QuestionReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}
