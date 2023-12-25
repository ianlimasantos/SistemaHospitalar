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
    }
}
