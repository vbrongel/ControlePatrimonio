using GerenciamentoPatrimonio.Dominio.Arguments.Usuario;
using GerenciamentoPatrimonio.Dominio.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GerenciamentoPatrimonio.Dominio.Interface.Service
{
    public interface IServiceUsuario 
    {
        InserirUsuarioResponse InserirResponse(InserirUsuarioRequest request);
        EditarUsuarioResponse EditarResponse(EditarUsuarioRequest request);
        RemoverUsuarioReponse RemoverResponse(RemoverUsuarioRequest request);
        UsuarioResponse SelecionarPorIdResponse(Guid id);
        IEnumerable<UsuarioResponse> ListarResponse();
        UsuarioResponse AutenticarResponse(string email, string senha);
    }
}
