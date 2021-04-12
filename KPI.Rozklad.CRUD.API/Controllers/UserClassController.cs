using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rozklad.CRUD.BLL.Models;
using Rozklad.CRUD.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPI.Rozklad.CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClassController : ControllerBase
    {
        private readonly IUserClassService _userClassService;

        public UserClassController(IUserClassService userClassService)
        {
            _userClassService = userClassService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserClassDTO entity)
        {
            await _userClassService.CreateAsync(entity);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _userClassService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var entity = await _userClassService.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UserClassDTO entity)
        {
            var updated = await _userClassService.UpdateAsync(entity);

            if (updated)
                return Ok(entity);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deleted = await _userClassService.DeleteAsync(id);

            if (deleted)
                return NoContent();
            return NotFound();
        }
    }
}
