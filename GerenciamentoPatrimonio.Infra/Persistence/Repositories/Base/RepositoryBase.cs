using GerenciamentoPatrimonio.Dominio.Entidades.Base;
using GerenciamentoPatrimonio.Dominio.Interface.Repository;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GerenciamentoPatrimonio.Infra.Repositories.Base
{
    public class RepositoryBase<TEntidade, TId> : IRepositoryBase<TEntidade, TId>
     where TEntidade : EntityBase
     where TId : struct
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public TEntidade Adicionar(TEntidade entidade)
        {
            return _context.Set<TEntidade>().Add(entidade);
        }

        public TEntidade Editar(TEntidade entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            return entidade;
        }

        public bool Existe(Func<TEntidade, bool> where)
        {
            try
            {
                return _context.Set<TEntidade>().Any(where);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntidade>(), includeProperties);
            }

            return query;
        }

        public TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return  Listar(includeProperties).FirstOrDefault(where);
        }

        public void Remover(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
        }

        public TEntidade SelecionarPorId(TId id, params Expression<Func<TEntidade, object>>[] expressions)
        {
            if (expressions.Any())
            {
                return Listar(expressions).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }

            return _context.Set<TEntidade>().Find(id);
        }

        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }
    }
}
