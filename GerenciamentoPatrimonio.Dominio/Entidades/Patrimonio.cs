using GerenciamentoPatrimonio.Dominio.Entidades.Base;
using System;
using System.Reflection;
using System.Security.Cryptography;

namespace GerenciamentoPatrimonio.Dominio.Entidades
{
    public class Patrimonio : EntityBase
    {
        public Patrimonio() { }
        public Patrimonio(string nome, Guid marcaId, string descricao)
        {
            Nome = nome;
            MarcaId.Id = marcaId;
            Descricao = descricao;
            Random numeroRandomico = new Random(); 
            NumeroTombo = numeroRandomico.Next();
        }

        public string ValidarCamposObrigatorios()
        {
            var mensagem = string.Empty;
            if (MarcaId == null) mensagem = string.Format("Id da Marca ", Mensagens.CAMPO_NULO) + Environment.NewLine;
            if (Nome == null) mensagem += string.Format("Nome ", Mensagens.CAMPO_NULO);
            return mensagem;
        }
        public void Alterar(string nome, Guid marcaId, string descricao)
        {
            Nome = nome;
            MarcaId.Id = marcaId;
            Descricao = descricao;
        }

        
        public  string Nome { get; private set; }
        public Marca MarcaId { get; private set; }
        public string Descricao { get; private set; }
        public int NumeroTombo { get; private set; }

        
    }
}
