using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Consulta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteAppService _pacienteAppService;

        public PacienteController(IPacienteAppService pacienteAppService)
        {
            _pacienteAppService = pacienteAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPaciente([FromBody] NovoPacienteViewModel vm)
        {
            var result = await _pacienteAppService.CadastrarPaciente(vm);
            if (result == null) return BadRequest("Não foi possível cadastrar o paciente");
            return Ok(result);
        }
    }
}
