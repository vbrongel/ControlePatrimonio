using GerenciamentoPatrimonio.Dominio.Arguments.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoPatrimonio.Dominio.Arguments.Patrimonio
{
    public class RemoverPatrimonioRequest : ArgumentsBase
    {
        public Guid Id {get; set;}
    }
}
