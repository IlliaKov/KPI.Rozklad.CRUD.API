using Rozklad.CRUD.DAL.Entities;
using Rozklad.CRUD.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rozklad.CRUD.DAL.Repositories.Implementations
{
    public class UserClassRepository : GenericRepository<UserClass>, IUserClassRepository
    {
        public UserClassRepository(RozkladContext contextOptions) : base(contextOptions) { }
    }
}
