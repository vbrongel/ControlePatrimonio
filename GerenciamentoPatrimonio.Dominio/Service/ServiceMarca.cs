using GerenciamentoPatrimonio.Dominio.Arguments.EnumStatusObjetos;
using GerenciamentoPatrimonio.Dominio.Arguments.Marca;
using GerenciamentoPatrimonio.Dominio.Entidades;
using GerenciamentoPatrimonio.Dominio.Interface.Repository;
using GerenciamentoPatrimonio.Dominio.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoPatrimonio.Dominio.Service
{
    public class ServiceMarca : IServiceMarca
    {
        private readonly IRepositoryMarca _repository;

        public ServiceMarca(IRepositoryMarca repository)
        {
            _repository = repository;
        }

        public EditarMarcaResponse EditarResponse(EditarMarcaRequest request)
        {
            var marca = _repository.SelecionarPorId(request.MarcaId);
            if (marca == null)
            {
                return new EditarMarcaResponse()
                {
                    Mensagens = string.Format("Marca", Mensagens.NAO_ENCONTRADO),
                    Status = EnumStatusObjeto.Sucesso
                };

            }
            marca.Alterar(request.MarcaId, request.Nome);
            _repository.Editar(marca);
            return new EditarMarcaResponse()
            {
                Nome = marca.Nome,
                MarcaId = marca.MarcaId,
                Mensagens = Mensagens.OPERACAO_SUCESSO,
                Status = EnumStatusObjeto.Sucesso
            };
        }

        public InserirMarcaResponse InserirResponse(InserirMarcaRequest request)
        {
            var existeMarca = _repository.Existe(x => x.MarcaId == request.MarcaId);
            if (existeMarca)
            {
                return new InserirMarcaResponse()
                {
                    Mensagens = string.Format("Marca", Mensagens.JA_EXISTE),
                    Status = EnumStatusObjeto.Sucesso
                };
            }


            var marca = new Marca(request.MarcaId, request.Nome);
            var mensagem = marca.ValidarCamposObrigatorios();

            if (marca != null)
            {
                return new InserirMarcaResponse()
                {
                    Mensagens = mensagem,
                    Status = EnumStatusObjeto.Sucesso
                };
            }
            _repository.Adicionar(marca);
            return new InserirMarcaResponse()
            {
                MarcaId = marca.Id,
                Mensagens = Mensagens.OPERACAO_SUCESSO,
                Status = EnumStatusObjeto.Sucesso
            };

        }

        public MarcaResponse ListarPorIdReponse(Guid id)
        {
            var marca = _repository.SelecionarPorId(id);
            if (marca == null) 
            {
                return new MarcaResponse()
                {
                    Mensagens = string.Format("Marca", Mensagens.NAO_ENCONTRADO),
                    Status = EnumStatusObjeto.Erro
                };
            }

            return new MarcaResponse()
            {
                MarcaId = marca.MarcaId,
                Nome = marca.Nome,
                Status = EnumStatusObjeto.Sucesso
            };
        }



        public RemoverMarcaResponse RemoverResponse(RemoverMarcaRequest request)
        {
            var marca = _repository.SelecionarPorId(request.Id);
            if (marca == null) return null;
            _repository.Remover(marca);
            return new RemoverMarcaResponse() { Mensagens = Mensagens.OPERACAO_SUCESSO, Status = EnumStatusObjeto.Sucesso };
        }

        MarcaResponse IServiceMarca.ListarPorIdReponse(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MarcaResponse> ListarResponse()
        {
            return _repository.Listar().Select(lista =>
            new MarcaResponse()
            {
                MarcaId = lista.Id,
                Nome = lista.Nome,
                Status = EnumStatusObjeto.Sucesso
            }
            ).ToList();
        }
    }
}
