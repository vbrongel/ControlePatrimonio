using GerenciamentoPatrimonio.Dominio.Entidades.Base;
using System;
using XGame.Domain.Extensions;

namespace GerenciamentoPatrimonio.Dominio.Entidades
{
    public class Usuario : EntityBase
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public Usuario(string nome, string email, string senha)
        {
            
            Nome = nome;
            Email = email;
            Senha = senha != null ? senha.ConvertToMD5() : string.Empty;
            
        }

        public Usuario(string email, string senha)
        {
            Email = email;
            Senha = senha.ConvertToMD5();
        }
        public void Alterar(string nome, string email)
        {
            Nome = nome;
            Email = email;

        }
        public string ValidarCamposObrigatorios()
        {
            var mensagem = string.Empty;
            if (Nome == null) mensagem = string.Format("Nome ", Mensagens.EM_BRANCO) + Environment.NewLine;
            if (Email == null) mensagem += string.Format("Email", Mensagens.EM_BRANCO) + Environment.NewLine;
            if (Senha == null) mensagem += ("Senha", Mensagens.EM_BRANCO);
            return mensagem;
        }

      
     
    }
}
