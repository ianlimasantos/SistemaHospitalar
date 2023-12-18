using AutoMapper;
using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModels;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Services
{
    public class PessoaAppService : IPessoaAppService
    {
        
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public PessoaAppService(IPessoaService pessoaService, IMapper mapper) 
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }
        public async Task<PessoaViewModel> CadastrarPessoa(NovaPessoaViewModel NovaPessoaViewModel)
        {
            Pessoa pessoa = new Pessoa(NovaPessoaViewModel.Nome,
                                       NovaPessoaViewModel.CPF,
                                       NovaPessoaViewModel.Email,
                                       NovaPessoaViewModel.DataNascimento);
            var pessoaCadastrada = await _pessoaService.CadastrarPessoa(pessoa);
            return _mapper.Map<PessoaViewModel>(pessoa);
        }

        public async Task<PessoaViewModel> AtualizarPessoa(AtualizarPessoaViewModel AtualizarPessoaViewModel)
        {
            var command = new AtualizarPessoaCommand
            {
                Id = AtualizarPessoaViewModel.Id,
                Nome = AtualizarPessoaViewModel.Nome,
                DataNascimento = AtualizarPessoaViewModel.DataNascimento
            };

            var pessoa = await _pessoaService.AtualizarPessoa(command);
            return _mapper.Map<PessoaViewModel>(pessoa);
        }

        public async Task<bool> DeletarPessoa(long id)
        {
            return await _pessoaService.DeletarPessoa(id);

        }

        public async Task<IEnumerable<PessoaViewModel>> ListarPessoas()
        {
            var lista = await _pessoaService.ListarPessoas();
            return _mapper.Map<IEnumerable<PessoaViewModel>>(lista);

        }

        public async Task<PessoaViewModel> ListarUmaPessoa(long id)
        {
            var pessoa = await _pessoaService.ListarUmaPessoa(id);
            return _mapper.Map<PessoaViewModel>(pessoa);

        } 
    }
}
