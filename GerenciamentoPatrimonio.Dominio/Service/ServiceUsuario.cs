using GerenciamentoPatrimonio.Dominio.Arguments.EnumStatusObjetos;
using GerenciamentoPatrimonio.Dominio.Arguments.Usuario;
using GerenciamentoPatrimonio.Dominio.Entidades;
using GerenciamentoPatrimonio.Dominio.Interface.Repository;
using GerenciamentoPatrimonio.Dominio.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace GerenciamentoPatrimonio.Dominio.Service
{
    public class ServiceUsuario : IServiceUsuario
    {

        private readonly IRepositoryUsuario _repository;

        public ServiceUsuario(IRepositoryUsuario repository)
        {
            _repository = repository;
        }

        public UsuarioResponse AutenticarResponse(string email, string senha)
        {
            if (email == null || senha == null)
            {
                return new UsuarioResponse() { Mensagens = Mensagens.CAMPOS_NULOS, Status = EnumStatusObjeto.Erro };
            }
            var usuario = new Usuario(email, senha);
            usuario = _repository.ObterPor(x => x.Email == email && x.Senha == senha);
            
            if (usuario == null)
            {
                return new UsuarioResponse() { Mensagens = Mensagens.CAMPOS_NULOS, Status = EnumStatusObjeto.Erro };
            }
            return new UsuarioResponse()
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Id = usuario.Id,
                Status = EnumStatusObjeto.Sucesso
            };

        }

      
        public EditarUsuarioResponse EditarResponse(EditarUsuarioRequest request)
        {
            var usuario = _repository.SelecionarPorId(request.Id);

            if (usuario == null)
            {
                return new EditarUsuarioResponse()
                {
                    Mensagens = string.Format("Usuário", Mensagens.NAO_ENCONTRADO),
                    Status = EnumStatusObjeto.Erro
                };
               
            }
            
            var mensagens = usuario.ValidarCamposObrigatorios();
            
            if (mensagens != null)
            {
                return new EditarUsuarioResponse()
                {
                    Mensagens = mensagens,
                    Status = EnumStatusObjeto.Erro
                };
            }
            _repository.Editar(usuario);
            return new EditarUsuarioResponse()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Status = EnumStatusObjeto.Sucesso

            };
                        
        }

        public InserirUsuarioResponse InserirResponse(InserirUsuarioRequest request)
        {
            var existeEmail = false;
            try
            {
                existeEmail = _repository.Existe(x => x.Email == request.Email);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            if (existeEmail)
            {
                return new InserirUsuarioResponse()
                {
                    Mensagens = Mensagens.JA_EXISTE, Status = EnumStatusObjeto.Erro
                };
            }

            var usuario = new Usuario(request.Nome, request.Email, request.Senha);
            var mensagem = usuario.ValidarCamposObrigatorios();
            
            if (mensagem != null)
                return new InserirUsuarioResponse() { Mensagens = mensagem, Status = EnumStatusObjeto.Erro };
            
            _repository.Adicionar(usuario);
            
            return new InserirUsuarioResponse()
            {
                Id = usuario.Id,
                Mensagens = Mensagens.OPERACAO_SUCESSO,
                Status = EnumStatusObjeto.Sucesso
            };
        }

    

        public IEnumerable<UsuarioResponse> ListarResponse()
        {
            return _repository.Listar().Select(lista =>
            new UsuarioResponse
            {
                Id = lista.Id,
                Email = lista.Email,
                Nome = lista.Nome,

            }

            ).ToList();
        }

        public RemoverUsuarioReponse RemoverResponse(RemoverUsuarioRequest request)
        {
            var usuario = _repository.SelecionarPorId(request.Id);
            if (usuario == null)
            {
                return new RemoverUsuarioReponse()
                {
                    Mensagens = Mensagens.OPERACAO_ERRO,
                    Status = EnumStatusObjeto.Erro
                };
            }
                
            _repository.Remover(usuario);
            return new RemoverUsuarioReponse()
            {
                Mensagens = Mensagens.OPERACAO_SUCESSO,
                Status = EnumStatusObjeto.Sucesso
            };
        }

        public UsuarioResponse SelecionarPorIdResponse(Guid id)
        {
            var usuario = _repository.SelecionarPorId(id);
            if (usuario == null)
            {
                return new UsuarioResponse()
                {
                    Mensagens = string.Format("Usuário ", Mensagens.NAO_ENCONTRADO),
                    Status = EnumStatusObjeto.Erro
                };
            }
            return new UsuarioResponse()
            {
                Email = usuario.Email,
                Nome = usuario.Nome,
                Mensagens = Mensagens.OPERACAO_SUCESSO,
                Status = EnumStatusObjeto.Sucesso
            };
        }
    }

}