using Rozklad.CRUD.DAL.Entities;
using Rozklad.CRUD.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rozklad.CRUD.DAL.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(RozkladContext contextOptions) : base(contextOptions) { }
    }
}
