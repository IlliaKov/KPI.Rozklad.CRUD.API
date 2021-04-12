using Rozklad.CRUD.DAL.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rozklad.CRUD.DAL.Entities
{
    public class Evaluation: MainEntity
    {
        public int Mark { get; set; }
        public DateTime Day { get; set; }



        public Guid? SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid? TeacherId { get; set; }
        public Guid? ClassId { get; set; }
        public User User { get; set; }
    }
}
