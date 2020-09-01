using GerenciamentoPatrimonio.Dominio.Arguments.EnumStatusObjetos;
using GerenciamentoPatrimonio.Dominio.Arguments.Patrimonio;
using GerenciamentoPatrimonio.Dominio.Entidades;
using GerenciamentoPatrimonio.Dominio.Interface.Repository;
using GerenciamentoPatrimonio.Dominio.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoPatrimonio.Dominio.Service
{
    public class ServicePatrimonio : IServicePatrimonio
    {
        private readonly IRepositoryPatrimonio _repository;

        public ServicePatrimonio(IRepositoryPatrimonio repository)
        {
            _repository = repository;
        }

        public EditarPatrimonioResponse EditarResponse(EditarPatrimonioRequest request)
        {
           
            var patrimonio = _repository.SelecionarPorId(request.MarcaId);
            if (patrimonio == null)
            {
                return new EditarPatrimonioResponse()
                {
                    Mensagens = Mensagens.CAMPOS_NULOS,
                    Status = EnumStatusObjeto.Erro
                    
                };
            }
                       
            patrimonio.Alterar(request.Nome, request.MarcaId, request.Descricao);
            _repository.Editar(patrimonio);
            return new EditarPatrimonioResponse()
            {
                Nome = patrimonio.Nome,
                MarcaId = patrimonio.MarcaId.Id,
                NumeroTombo = patrimonio.NumeroTombo,
                Descricao = patrimonio.Descricao,
                Mensagens = Mensagens.OPERACAO_SUCESSO,
                Status = EnumStatusObjeto.Sucesso
            };

        }

        public InserirPatrimonioResponse InserirResponse(InserirPatrimonioRequest request)
        {
            
            var patrimonio = new Patrimonio(request.Nome, request.MarcaId, request.Mensagens);
            var mensagem = patrimonio.ValidarCamposObrigatorios();

            if (mensagem != null) return new InserirPatrimonioResponse() { Mensagens = mensagem, Status = EnumStatusObjeto.Erro };

            _repository.Adicionar(patrimonio);
            return new InserirPatrimonioResponse()
            {
                Mensagens = Mensagens.OPERACAO_SUCESSO,
                Status = EnumStatusObjeto.Sucesso
            };
        }



        public IEnumerable<PatrimonioResponse> ListarResponse()
        {
          
          
          return  _repository.Listar().Select(lista => new PatrimonioResponse
          {
              MarcaId = lista.MarcaId.Id,
              Descricao = lista.Descricao,
              Nome = lista.Nome,
              NumeroTombo = lista.NumeroTombo
          }).ToList();
          
        }

        public RemoverPatrimonioResponse RemoverResponse(RemoverPatrimonioRequest request)
        {
            var patrimonio = _repository.SelecionarPorId(request.Id);
            if (patrimonio == null)
            {
                return new RemoverPatrimonioResponse()
                {
                    Mensagens = "Patrimônio não existe",
                    Status = EnumStatusObjeto.Erro
                };
            }
            _repository.Remover(patrimonio);
            return new RemoverPatrimonioResponse() { Mensagens = Mensagens.OPERACAO_SUCESSO, Status = EnumStatusObjeto.Sucesso };

        }

        public PatrimonioResponse ListarPorIdReponse(Guid id)
        {
            var patrimonio = _repository.SelecionarPorId(id);
            if (patrimonio == null)
            {
                return new PatrimonioResponse()
                {
                    Mensagens = string.Format("Patrimônio", Mensagens.NAO_ENCONTRADO),
                    Status = EnumStatusObjeto.Erro
                };
            }
            
            return new PatrimonioResponse()
            {
                MarcaId = patrimonio.MarcaId.Id,
                Descricao = patrimonio.Descricao,
                Nome = patrimonio.Nome,
                NumeroTombo = patrimonio.NumeroTombo,
                Status = EnumStatusObjeto.Sucesso
            };
        }
    }
}
