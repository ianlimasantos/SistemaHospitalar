using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModels;
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
    }
}
