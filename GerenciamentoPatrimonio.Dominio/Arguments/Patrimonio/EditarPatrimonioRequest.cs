using GerenciamentoPatrimonio.Dominio.Arguments.Base;
using System;

namespace GerenciamentoPatrimonio.Dominio.Arguments.Patrimonio
{
    public class EditarPatrimonioRequest : ArgumentsBase
    {
        public string Nome { get; set; }
        public  Guid MarcaId { get; set; }
        public string Descricao { get; set; }
    }
}
