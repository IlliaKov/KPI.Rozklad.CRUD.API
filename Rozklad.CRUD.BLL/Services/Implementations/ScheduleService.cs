using Rozklad.CRUD.BLL.Models;
using Rozklad.CRUD.BLL.Services.Interfaces;
using Rozklad.CRUD.DAL.Entities;
using Rozklad.CRUD.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.CRUD.BLL.Services.Implementations
{
    public class ScheduleService: IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<int> CountAllAsync()
        {
            return await _scheduleRepository.CountAllAsync();
        }

        public async Task CreateAsync(ScheduleDTO entity)
        {
            Schedule dbEntity = new Schedule()
            {
                Id = entity.Id,
                IsSecondWeek = entity.IsSecondWeek,
                Weekday = entity.Weekday,
                Lesson = entity.Lesson,
                SubjectId = entity.SubjectId,
                TeacherId = entity.TeacherId,
                ClassId = entity.ClassId
            };

            await _scheduleRepository.CreateAsync(dbEntity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _scheduleRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ScheduleDTO>> GetAllAsync()
        {
            return (await _scheduleRepository.GetAllAsync()).Select
                (m => new ScheduleDTO()
                {
                    Id = m.Id,
                    IsSecondWeek = m.IsSecondWeek,
                    Weekday = m.Weekday,
                    Lesson = m.Lesson,
                    SubjectId = m.SubjectId,
                    TeacherId = m.TeacherId,
                    ClassId = m.ClassId
                });
        }

        public async Task<ScheduleDTO> GetByIdAsync(Guid id)
        {
            Schedule fromDb = await _scheduleRepository.GetByIdAsync(id);

            ScheduleDTO dbEntity = new ScheduleDTO()
            {
                Id = fromDb.Id,
                IsSecondWeek = fromDb.IsSecondWeek,
                Weekday = fromDb.Weekday,
                Lesson = fromDb.Lesson,
                SubjectId = fromDb.SubjectId,
                TeacherId = fromDb.TeacherId,
                ClassId = fromDb.ClassId
            };
            return dbEntity;
        }

        public async Task<bool> UpdateAsync(ScheduleDTO entity)
        {
            var entityDb = await _scheduleRepository.GetByIdAsync(entity.Id);

            entityDb.Id = entity.Id;
            entityDb.IsSecondWeek = entity.IsSecondWeek;
            entityDb.Weekday = entity.Weekday;
            entityDb.Lesson = entity.Lesson;
            entityDb.SubjectId = entity.SubjectId;
            entityDb.TeacherId = entity.TeacherId;
            entityDb.ClassId = entity.ClassId;

            return await _scheduleRepository.UpdateAsync(entityDb);
        }
    }
}
