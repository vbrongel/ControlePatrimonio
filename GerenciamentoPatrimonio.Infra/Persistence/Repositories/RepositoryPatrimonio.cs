using GerenciamentoPatrimonio.Dominio.Entidades;
using GerenciamentoPatrimonio.Dominio.Interface.Repository;
using GerenciamentoPatrimonio.Infra.Repositories.Base;
using System;

namespace GerenciamentoPatrimonio.Infra.Repositories
{
    public class RepositoryPatrimonio : RepositoryBase<Patrimonio, Guid>, IRepositoryPatrimonio
    {
        private readonly Context _context;
   
        public RepositoryPatrimonio(Context context) : base(context)
        {
            _context = context;
        }
    }
}
