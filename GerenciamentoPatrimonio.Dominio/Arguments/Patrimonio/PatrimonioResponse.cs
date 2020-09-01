using GerenciamentoPatrimonio.Dominio.Arguments.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoPatrimonio.Dominio.Arguments.Patrimonio
{
    public class PatrimonioResponse : ArgumentsBase
    {
        public string Nome { get;  set; }
        public Guid MarcaId { get;  set; }
        public string Descricao { get;  set; }
        public int NumeroTombo { get;  set; }
     }
}
