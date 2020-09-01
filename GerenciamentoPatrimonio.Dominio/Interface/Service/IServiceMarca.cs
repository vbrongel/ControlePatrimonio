using GerenciamentoPatrimonio.Dominio.Arguments.Marca;
using GerenciamentoPatrimonio.Dominio.Entidades;
using GerenciamentoPatrimonio.Dominio.Interface.Repository;
using System;
using System.Collections.Generic;

namespace GerenciamentoPatrimonio.Dominio.Interface.Service
{
    public interface IServiceMarca 
    {
        InserirMarcaResponse InserirResponse(InserirMarcaRequest request);
        EditarMarcaResponse EditarResponse(EditarMarcaRequest request);
        RemoverMarcaResponse RemoverResponse(RemoverMarcaRequest request);
        MarcaResponse ListarPorIdReponse(Guid id);
        IEnumerable<MarcaResponse> ListarResponse();
    }
}
