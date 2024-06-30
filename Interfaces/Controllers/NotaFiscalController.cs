using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using teste_tecnico_api.Application.Services;
using teste_tecnico_api.Domain.Models;

namespace teste_tecnico_api.Interfaces.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly INotaFiscalService _service;

        public NotaFiscalController(INotaFiscalService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotaFiscal(NotaFiscal notaFiscal)
        {
            await _service.AddNotaFiscalAsync(notaFiscal);
            return CreatedAtAction(nameof(GetNotaFiscalById), new { id = notaFiscal.Id }, notaFiscal);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotaFiscalById(string id)
        {
            var notaFiscal = await _service.GetNotaFiscalByIdAsync(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }
            return Ok(notaFiscal);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotasFiscais()
        {
            var notasFiscais = await _service.GetAllNotasFiscaisAsync();
            return Ok(notasFiscais);
        }
    }
}
