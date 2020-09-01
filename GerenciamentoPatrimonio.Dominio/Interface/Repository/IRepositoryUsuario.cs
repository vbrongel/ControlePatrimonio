using GerenciamentoPatrimonio.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoPatrimonio.Dominio.Interface.Repository
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario, Guid>
    {
    }
}
