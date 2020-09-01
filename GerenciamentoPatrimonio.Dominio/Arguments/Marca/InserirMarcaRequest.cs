using GerenciamentoPatrimonio.Dominio.Arguments.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoPatrimonio.Dominio.Arguments.Marca
{
    public class InserirMarcaRequest : ArgumentsBase
    {
        public string Nome { get; set; }
        public Guid MarcaId { get; set; }
    }
}
