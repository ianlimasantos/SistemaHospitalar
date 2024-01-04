using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModels;
using Cadastro.Domain.Models.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Consulta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaAppService _consultaAppService;

        public ConsultaController(IConsultaAppService consultaAppService)
        {
            _consultaAppService = consultaAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarConsulta([FromBody] NovaConsultaViewModel vm)
        {
            var result = await _consultaAppService.CadastrarConsulta(vm);
            if (result == null) return BadRequest("Não foi possível realizar o cadastro");
            return Ok(result);
        }

        
        [HttpPut]
        public async Task<IActionResult> AtualizarConsulta([FromBody] AtualizarConsultaViewModel vm)
        {
            var result = await _consultaAppService.AtualizarConsulta(vm);
            if (result == null) return BadRequest("Ops, algo deu errado!");
            return Ok(result);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ListarConsultaPeloId(long id)
        {
            var result = await _consultaAppService.ListarConsultaPeloId(id);
            if(result == null) return NotFound("Não foi encontrado nenhum usuário com esse id para ser atualizado");
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletarConsultaPeloId(long id)
        {
            var result = await _consultaAppService.DeletarConsulta(id);
            if (!result) return BadRequest("Não foi possível deletar o usuário");
            return Ok("Excluído com sucesso!");
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodasConsultas()
        {
            var result = await _consultaAppService.ListarConsultas();
            if (result == null) return BadRequest("Não foi possível achar nenhuma consulta");
            return Ok(result);
        }
    }
}
