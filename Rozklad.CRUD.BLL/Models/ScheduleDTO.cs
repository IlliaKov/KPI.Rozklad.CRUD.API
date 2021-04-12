using System;
using System.Collections.Generic;
using System.Text;

namespace Rozklad.CRUD.BLL.Models
{
    public class ScheduleDTO
    {
        public Guid Id { get; set; }
        public bool IsSecondWeek { get; set; }
        public int Weekday { get; set; }
        public int Lesson { get; set; }



        public Guid? SubjectId { get; set; }
        public SubjectDTO Subject { get; set; }

        public Guid? TeacherId { get; set; }
        public Guid? ClassId { get; set; }
        public UserDTO User { get; set; }
    }
}
