using GerenciamentoPatrimonio.Dominio.Arguments.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoPatrimonio.Dominio.Arguments.Usuario
{
    public class UsuarioResponse : ArgumentsBase
    {
        public Guid Id { get; set; }
        public string Nome { get;  set; }
        public string Email { get;  set; }
       
    }
}
