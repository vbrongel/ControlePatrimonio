using GerenciamentoPatrimonio.Dominio.Arguments.Base;
using System;

namespace GerenciamentoPatrimonio.Dominio.Arguments.Marca
{
    public class InserirMarcaResponse : ArgumentsBase
    {
        public Guid MarcaId { get; set; }
        
    }
}
