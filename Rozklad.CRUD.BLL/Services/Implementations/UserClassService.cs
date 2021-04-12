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
    public class UserClassService : IUserClassService
    {
        private readonly IUserClassRepository _userClassRepository;

        public UserClassService(IUserClassRepository userClassRepository)
        {
            _userClassRepository = userClassRepository;
        }

        public async Task<int> CountAllAsync()
        {
            return await _userClassRepository.CountAllAsync();
        }

        public async Task CreateAsync(UserClassDTO entity)
        {
            UserClass dbEntity = new UserClass()
            {
                Id = entity.Id,
                Name = entity.Name
            };

            await _userClassRepository.CreateAsync(dbEntity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _userClassRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserClassDTO>> GetAllAsync()
        {
            return (await _userClassRepository.GetAllAsync()).Select
                (m => new UserClassDTO()
                {
                    Id = m.Id,
                    Name = m.Name
                });
        }

        public async Task<UserClassDTO> GetByIdAsync(Guid id)
        {
            UserClass fromDb = await _userClassRepository.GetByIdAsync(id);

            UserClassDTO entityDb = new UserClassDTO()
            {
                Id = fromDb.Id,
                Name = fromDb.Name
            };
            return entityDb;
        }

        public async Task<bool> UpdateAsync(UserClassDTO entity)
        {
            var entityDb = await _userClassRepository.GetByIdAsync(entity.Id);

            entityDb.Id = entity.Id;
            entityDb.Name = entity.Name;

            return await _userClassRepository.UpdateAsync(entityDb);
        }
    }
}
