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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> CountAllAsync()
        {
            return await _userRepository.CountAllAsync();
        }

        public async Task CreateAsync(UserDTO entity)
        {
            User dbEntity = new User()
            {
                Id = entity.Id,
                Name = entity.Name,
                Login = entity.Login,
                Password = entity.Password,
                UserClassId = entity.UserClassId
            };

            await _userRepository.CreateAsync(dbEntity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            return (await _userRepository.GetAllAsync()).Select
                (m => new UserDTO()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Login = m.Login,
                    Password = m.Password,
                    UserClassId = m.UserClassId
                });
        }

        public async Task<UserDTO> GetByIdAsync(Guid id)
        {
            User fromDb = await _userRepository.GetByIdAsync(id);

            UserDTO instructorDTO = new UserDTO()
            {
                Id = fromDb.Id,
                Name = fromDb.Name,
                Login = fromDb.Login,
                Password = fromDb.Password,
                UserClassId = fromDb.UserClassId
            };
            return instructorDTO;
        }

        public async Task<bool> UpdateAsync(UserDTO entity)
        {
            var entityDb = await _userRepository.GetByIdAsync(entity.Id);

            entityDb.Id = entity.Id;
            entityDb.Name = entity.Name;
            entityDb.Login = entity.Login;
            entityDb.Password = entity.Password;
            entityDb.UserClassId = entity.UserClassId;

            return await _userRepository.UpdateAsync(entityDb);
        }
    }
}
