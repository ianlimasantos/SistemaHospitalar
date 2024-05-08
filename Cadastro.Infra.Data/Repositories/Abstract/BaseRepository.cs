using Cadastro.Domain.Interfaces;
using Cadastro.Domain.Interfaces.Repositories;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cadastro.Infra.Data.EF;

namespace Cadastro.Infra.Data.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly CadastroContext _context;

        public BaseRepository(CadastroContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            var teste = await _context.Set<T>().FindAsync(id);
            return teste;
        }

    }
}
