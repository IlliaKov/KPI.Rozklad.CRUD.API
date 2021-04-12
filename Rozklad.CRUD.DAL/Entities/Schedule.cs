using System;
using System.Collections.Generic;
using System.Text;
using Rozklad.CRUD.DAL.Entities.BaseEntity;

namespace Rozklad.CRUD.DAL.Entities
{
    public class Schedule : MainEntity
    {
        public bool IsSecondWeek { get; set; }
        public int Weekday { get; set; }
        public int Lesson { get; set; }



        public Guid? SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid? TeacherId { get; set; }
        public Guid? ClassId { get; set; }
        public User User { get; set; }
    }
}
