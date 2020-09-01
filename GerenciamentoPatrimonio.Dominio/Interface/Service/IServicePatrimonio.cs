using GerenciamentoPatrimonio.Dominio.Arguments.Patrimonio;
using GerenciamentoPatrimonio.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace GerenciamentoPatrimonio.Dominio.Interface.Service
{
    public interface IServicePatrimonio 
    {
        InserirPatrimonioResponse InserirResponse(InserirPatrimonioRequest request);
        EditarPatrimonioResponse EditarResponse(EditarPatrimonioRequest request);
        RemoverPatrimonioResponse RemoverResponse(RemoverPatrimonioRequest request);
        PatrimonioResponse ListarPorIdReponse(Guid id);
        IEnumerable<PatrimonioResponse> ListarResponse();
    }
}
