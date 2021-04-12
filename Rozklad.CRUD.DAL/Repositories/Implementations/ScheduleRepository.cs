using Rozklad.CRUD.DAL.Entities;
using Rozklad.CRUD.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rozklad.CRUD.DAL.Repositories.Implementations
{
    public class ScheduleRepository: GenericRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(RozkladContext contextOptions) : base(contextOptions) { }
    }
}
