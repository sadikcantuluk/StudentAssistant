using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class LessonMessage
    {
        public int LessonMessageID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
