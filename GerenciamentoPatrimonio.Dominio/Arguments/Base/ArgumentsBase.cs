using GerenciamentoPatrimonio.Dominio.Arguments.EnumStatusObjetos;

namespace GerenciamentoPatrimonio.Dominio.Arguments.Base
{
    public class ArgumentsBase
    {
        public string Mensagens { get; set; }
        public EnumStatusObjeto Status { get; set; }
    }
}
