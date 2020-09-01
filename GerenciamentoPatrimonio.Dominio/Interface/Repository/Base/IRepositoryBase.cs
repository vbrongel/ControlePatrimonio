using System;
using System.Linq;
using System.Linq.Expressions;

namespace GerenciamentoPatrimonio.Dominio.Interface.Repository
{
    public interface IRepositoryBase<TEntidade, TId>
    where TEntidade : class
    where TId : struct
    {
        bool Existe(Func<TEntidade, bool> where);
        IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties);
        TEntidade SelecionarPorId(TId id, params Expression<Func<TEntidade, object>>[] expressions);
        TEntidade Adicionar(TEntidade entidade);
        TEntidade Editar(TEntidade entidade);
        void Remover(TEntidade entidade);

        TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties);


    }
}

