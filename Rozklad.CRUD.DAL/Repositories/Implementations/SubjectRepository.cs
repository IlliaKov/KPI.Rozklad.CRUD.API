using Rozklad.CRUD.DAL.Entities;
using Rozklad.CRUD.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rozklad.CRUD.DAL.Repositories.Implementations
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(RozkladContext contextOptions) : base(contextOptions) { }
    }
}
