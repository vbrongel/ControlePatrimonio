using GerenciamentoPatrimonio.Dominio.Entidades;
using GerenciamentoPatrimonio.Dominio.Interface.Repository;
using GerenciamentoPatrimonio.Infra.Repositories.Base;
using System;

namespace GerenciamentoPatrimonio.Infra.Repositories
{
    public class RepositoryUsuario : RepositoryBase<Usuario, Guid>, IRepositoryUsuario
    {
        private readonly Context _context;

        public RepositoryUsuario(Context context) : base(context)
        {
            _context = context;
        }
    }
}
