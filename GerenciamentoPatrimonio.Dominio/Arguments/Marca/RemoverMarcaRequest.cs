using GerenciamentoPatrimonio.Dominio.Arguments.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoPatrimonio.Dominio.Arguments.Marca
{
    public class RemoverMarcaRequest : ArgumentsBase
    {
        public Guid Id { get; set; }
    }
}
