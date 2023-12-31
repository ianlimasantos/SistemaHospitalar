﻿using Cadastro.Domain.Models;

namespace Cadastro.Domain.Interfaces.Repositories
{
    public interface IMedicoRepository : IBaseRepository<Medico>
    {
        Task CadastrarMedico(Medico medico);
        Task AtualizarMedico(Medico medico);
        Task<IEnumerable<Medico>> ListarMedicos();
        Task DeletarMedico(Medico medico);
    }
}
