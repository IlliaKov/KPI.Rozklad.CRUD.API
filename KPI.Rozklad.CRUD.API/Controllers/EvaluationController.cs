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
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationService _evaluationService;

        public EvaluationController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(EvaluationDTO entity)
        {
            await _evaluationService.CreateAsync(entity);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _evaluationService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var entity = await _evaluationService.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] EvaluationDTO entity)
        {
            var updated = await _evaluationService.UpdateAsync(entity);

            if (updated)
                return Ok(entity);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deleted = await _evaluationService.DeleteAsync(id);

            if (deleted)
                return NoContent();
            return NotFound();
        }
    }
}
