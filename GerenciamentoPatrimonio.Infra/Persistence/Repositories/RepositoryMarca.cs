using GerenciamentoPatrimonio.Dominio.Entidades;
using GerenciamentoPatrimonio.Dominio.Interface.Repository;
using GerenciamentoPatrimonio.Infra.Repositories.Base;
using System;

namespace GerenciamentoPatrimonio.Infra.Repositories
{
    public class RepositoryMarca : RepositoryBase<Marca, Guid>, IRepositoryMarca
    {
        private readonly Context _context;

        public RepositoryMarca(Context context) : base(context)
        {
            _context = context;
        }
    }
}
