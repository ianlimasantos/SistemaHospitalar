using Cadastro.Application.Services;
using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Consulta.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaAppService _pessoaAppService;
        public PessoaController(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PaginaComForms()
        {
            return View("CadastrarPessoa");
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPessoa([FromBody] NovaPessoaViewModel vm)
        {
            var result = await _pessoaAppService.CadastrarPessoa(vm);
            var a = 'a';
            return Json (new { Status = true, Redirect = @Url.Action("ListarPessoas", "Pessoa") });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ListarPessoaPeloId(long id)
        {
            var result = await _pessoaAppService.ListarUmaPessoa(id);
            if (result == null) return BadRequest("Não foi possível listar nenhum usuário");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListarPessoas()
        {
            IEnumerable<PessoaViewModel> pessoasViewModel = await _pessoaAppService.ListarPessoas();
            return Json(new { Entity = pessoasViewModel });
        }

        [HttpGet]
        public async Task<IActionResult> ListarPessoasTela()
        {
            return View("ListarPessoas");
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarPessoa([FromBody] AtualizarPessoaViewModel vm)
        {
            var result = await _pessoaAppService.AtualizarPessoa(vm);
            if (result == null) return BadRequest("Não foi possível atualizar a pessoa");
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletarPessoa(long id)
        {
            var result = await _pessoaAppService.DeletarPessoa(id);
            if (!result) return BadRequest("Não foi possível deletar a pessoa");
            return Ok("A pessoa de id {id} foi removida com sucesso!");
        }
    }
}
