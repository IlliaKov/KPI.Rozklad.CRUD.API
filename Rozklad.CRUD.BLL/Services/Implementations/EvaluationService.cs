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
    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationService(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public async Task<int> CountAllAsync()
        {
            return await _evaluationRepository.CountAllAsync();
        }

        public async Task CreateAsync(EvaluationDTO entity)
        {
            Evaluation dbEntity = new Evaluation()
            {
                Id = entity.Id,
                Mark = entity.Mark,
                Day = entity.Day,
                SubjectId = entity.SubjectId,
                TeacherId = entity.TeacherId,
                ClassId = entity.ClassId
            };

            await _evaluationRepository.CreateAsync(dbEntity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _evaluationRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EvaluationDTO>> GetAllAsync()
        {
            return (await _evaluationRepository.GetAllAsync()).Select
                (m => new EvaluationDTO()
                {
                    Id = m.Id,
                    Mark = m.Mark,
                    Day = m.Day,
                    SubjectId = m.SubjectId,
                    TeacherId = m.TeacherId,
                    ClassId = m.ClassId
                });
        }

        public async Task<EvaluationDTO> GetByIdAsync(Guid id)
        {
            Evaluation fromDb = await _evaluationRepository.GetByIdAsync(id);

            EvaluationDTO dbEntity = new EvaluationDTO()
            {
                Id = fromDb.Id,
                Mark = fromDb.Mark,
                Day = fromDb.Day,
                SubjectId = fromDb.SubjectId,
                TeacherId = fromDb.TeacherId,
                ClassId = fromDb.ClassId
            };
            return dbEntity;
        }

        public async Task<bool> UpdateAsync(EvaluationDTO entity)
        {
            var entityDb = await _evaluationRepository.GetByIdAsync(entity.Id);

            entityDb.Id = entity.Id;
            entityDb.Mark = entity.Mark;
            entityDb.Day = entity.Day;
            entityDb.SubjectId = entity.SubjectId;
            entityDb.TeacherId = entity.TeacherId;
            entityDb.ClassId = entity.ClassId;

            return await _evaluationRepository.UpdateAsync(entityDb);
        }
    }
}
