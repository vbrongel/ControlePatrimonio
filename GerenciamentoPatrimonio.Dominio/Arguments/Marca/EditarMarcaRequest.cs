using GerenciamentoPatrimonio.Dominio.Arguments.Base;
using System;

namespace GerenciamentoPatrimonio.Dominio.Arguments.Marca
{
    public class EditarMarcaRequest : ArgumentsBase
    {
        public string Nome { get; set; }
        public Guid MarcaId { get; set; }
       
    }
}
