using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Consulta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoAppService _medicoAppService;

        public MedicoController(IMedicoAppService medicoAppService)
        {
            _medicoAppService = medicoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarMedico([FromBody] NovoMedicoViewModel vm)
        {
            var result = await _medicoAppService.CadastrarMedico(vm);
            if (result == null) return BadRequest("Não foi possível cadastrar o usuário.");
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarMedico([FromBody] AtualizarMedicoViewModel vm)
        {
            var result = await _medicoAppService.AtualizarMedico(vm);
            if (result == null) return BadRequest("Não havia nenhum médico com esse id");
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletarMedico(long id)
        {
            var result = await _medicoAppService.DeletarMedico(id);
            if (!result) return BadRequest($"Não foi possível excluir o Médico{id}");
            if(result) return Ok("Excluído!");
            return NotFound($"Não foi achado o médico com o id - {id}");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ListarMedicoPorId(long id)
        {
            var result = await _medicoAppService.ListarMedicoPorId(id);
            if (result == null) return BadRequest($"Não tem nenhum médico com o id {id}");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodosMedicos()
        {
            var result = await _medicoAppService.ListarMedicos();
            if (result == null) return BadRequest("Não tem nenhum médico cadastrado");
            return Ok(result);
        } 

    }
}
