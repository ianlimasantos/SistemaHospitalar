using Cadastro.Application.Services;
using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Consulta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaAppService _pessoaAppService; 
        public PessoaController(IPessoaAppService pessoaAppService) 
        {
            _pessoaAppService = pessoaAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPessoa([FromBody] NovaPessoaViewModel vm)
        {
            var result = await _pessoaAppService.CadastrarPessoa(vm);
            if (result == null) return BadRequest("Não foi possível cadastrar nenhum usuário");
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ListarPessoaPeloId(long id)
        {
            var result = await _pessoaAppService.ListarUmaPessoa(id);
            if (result == null) return BadRequest("Não foi possível listar nenhum usuário");
            return Ok(result); 
        }

        [HttpGet]
        public async Task<IActionResult> ListarPessoas()
        {
            var result = await _pessoaAppService.ListarPessoas();
            if (result == null) return BadRequest("Não foi possível listar os usuários");
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarPessoa([FromBody] AtualizarPessoaViewModel vm)
        {
            var result = await _pessoaAppService.AtualizarPessoa(vm);
            if (result == null) return BadRequest("Não foi possível atualizar a pessoa");
            return Ok(result);
        }
    }
}
