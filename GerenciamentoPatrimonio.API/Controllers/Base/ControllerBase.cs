using GerenciamentoPatrimonio.Dominio.Arguments.EnumStatusObjetos;
using GerenciamentoPatrimonio.Infra.Transactions;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GerenciamentoPatrimonio.API.Controllers.Base
{
    public class ControllerBase : ApiController
    {

        private readonly IUnityOfWork _unityContainer;

        public ControllerBase(IUnityOfWork unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public HttpResponseMessage Response(object response, EnumStatusObjeto status)
        {
            if (status == EnumStatusObjeto.Sucesso)
            {
                try
                {
                    _unityContainer.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Erro: " +
                        $"{e.Message}");
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
        }

    }
}