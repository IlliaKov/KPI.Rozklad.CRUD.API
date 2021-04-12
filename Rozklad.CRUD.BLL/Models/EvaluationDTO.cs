using System;
using System.Collections.Generic;
using System.Text;

namespace Rozklad.CRUD.BLL.Models
{
    public class EvaluationDTO
    {
        public Guid Id { get; set; }
        public int Mark { get; set; }
        public DateTime Day { get; set; }



        public Guid? SubjectId { get; set; }
        public SubjectDTO Subject { get; set; }

        public Guid? TeacherId { get; set; }
        public Guid? ClassId { get; set; }
        public UserDTO User { get; set; }
    }
}
