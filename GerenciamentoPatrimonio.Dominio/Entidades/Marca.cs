using GerenciamentoPatrimonio.Dominio.Entidades.Base;
using System;

namespace GerenciamentoPatrimonio.Dominio.Entidades
{
    public class Marca : EntityBase
    {
        public Marca(Guid marcaId, string nome)
        {
            MarcaId = marcaId;
            Nome = nome;
        }

        public string ValidarCamposObrigatorios()
        {
            var mensagem = string.Empty;
            if (MarcaId == null) mensagem = "Preencha o id da marca " + Environment.NewLine;
            if (Nome == null) mensagem += "Preencha o nome";
            return mensagem;
        }

        public void Alterar(Guid marcaId, string nome)
        {
            MarcaId = marcaId;
            Nome = nome;
        }

        
        public Guid  MarcaId { get; private set; }
        public string Nome { get; private set; }
    }
}
