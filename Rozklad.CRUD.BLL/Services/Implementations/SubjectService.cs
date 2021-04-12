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
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<int> CountAllAsync()
        {
            return await _subjectRepository.CountAllAsync();
        }

        public async Task CreateAsync(SubjectDTO entity)
        {
            Subject dbEntity = new Subject()
            {
                Id = entity.Id,
                Name = entity.Name
            };

            await _subjectRepository.CreateAsync(dbEntity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _subjectRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubjectDTO>> GetAllAsync()
        {
            return (await _subjectRepository.GetAllAsync()).Select
                (m => new SubjectDTO()
                {
                    Id = m.Id,
                    Name = m.Name
                });
        }

        public async Task<SubjectDTO> GetByIdAsync(Guid id)
        {
            Subject fromDb = await _subjectRepository.GetByIdAsync(id);

            SubjectDTO dbEntity = new SubjectDTO()
            {
                Id = fromDb.Id,
                Name = fromDb.Name
            };
            return dbEntity;
        }

        public async Task<bool> UpdateAsync(SubjectDTO entity)
        {
            var entityDb = await _subjectRepository.GetByIdAsync(entity.Id);

            entityDb.Id = entity.Id;
            entityDb.Name = entity.Name;

            return await _subjectRepository.UpdateAsync(entityDb);
        }
    }
}
