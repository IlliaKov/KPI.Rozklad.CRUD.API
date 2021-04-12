using System;
using System.Collections.Generic;
using System.Text;

namespace Rozklad.CRUD.BLL.Models
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }



        public Guid? UserClassId { get; set; }
        public UserClassDTO UserClass { get; set; }
    }
}
