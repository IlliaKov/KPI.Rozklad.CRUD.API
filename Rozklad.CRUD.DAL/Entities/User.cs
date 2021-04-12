using Rozklad.CRUD.DAL.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rozklad.CRUD.DAL.Entities
{
    public class User: MainEntity
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }



        public Guid? UserClassId { get; set; }
        public UserClass UserClass { get; set; }
    }
}
