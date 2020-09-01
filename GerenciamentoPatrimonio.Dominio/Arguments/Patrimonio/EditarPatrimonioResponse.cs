using GerenciamentoPatrimonio.Dominio.Arguments.Base;
using System;

namespace GerenciamentoPatrimonio.Dominio.Arguments.Patrimonio
{
    public class EditarPatrimonioResponse : ArgumentsBase
    {
        public string Nome { get; set; }
        public Guid MarcaId { get; set; }
        public int NumeroTombo { get; set; }
        public string Descricao { get; set; }
    }
}
