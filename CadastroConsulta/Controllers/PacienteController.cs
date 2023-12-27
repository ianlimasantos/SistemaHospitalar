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

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletarPaciente(long id)
        {
            var result = await _pacienteAppService.DeletarPaciente(id);
            if (!result) return BadRequest("Não foi possível deletar paciente");
            return Ok("Foi deletado com sucesso");
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodosPacientes()
        {
            var result = await _pacienteAppService.ListarPacientes();
            if (result == null) return NotFound("Não tem nenhum paciente cadastrado");
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ListarPacientePorId(long id)
        {
            var result = await _pacienteAppService.ListarPacientePorId(id);
            if (result == null) return NotFound("Não há nenhum paciente com esse id");
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarPaciente([FromBody] AtualizarPacienteViewModel vm)
        {
            var result = await _pacienteAppService.AtualizarPaciente(vm);
            if (result == null) return BadRequest("Não foi possível atualizar o paciente");
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> InativarPaciente(long id)
        {
            var result = await _pacienteAppService.InativarPaciente(id);
            if (result == null) return BadRequest("Não foi possível inativar o paciente");
            return Ok(result);
        }
    }
}
