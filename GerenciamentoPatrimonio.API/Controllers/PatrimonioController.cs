using GerenciamentoPatrimonio.API.Controllers.Base;
using GerenciamentoPatrimonio.Dominio.Arguments.EnumStatusObjetos;
using GerenciamentoPatrimonio.Dominio.Arguments.Patrimonio;
using GerenciamentoPatrimonio.Dominio.Interface.Service;
using GerenciamentoPatrimonio.Infra.Transactions;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GerenciamentoPatrimonio.API.Controllers
{
   
    public class PatrimonioController : ControllerBase
    {
        private readonly IServicePatrimonio _service;
        public PatrimonioController(IUnityOfWork unityOfWork, IServicePatrimonio service) : base(unityOfWork)
        {
            _service = service;
        }

        
        [HttpPost]
        public HttpResponseMessage Inserir(InserirPatrimonioRequest request)
        {
            try
            {
                var response = _service.InserirResponse(request);
                return Response(response, response.Status);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
       
        [HttpPut]
        public HttpResponseMessage Editar(EditarPatrimonioRequest request)
        {
            try
            {
                var response = _service.EditarResponse(request);
                return Response(response, response.Status);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        
        [HttpDelete]
        public HttpResponseMessage Remover(RemoverPatrimonioRequest request)
        {
            try
            {
                var response = _service.RemoverResponse(request);
                return Response(response, response.Status);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        
        [HttpGet]
        public HttpResponseMessage BuscarPatrimonio(Guid id)
        {
            try
            {
                var response = _service.ListarPorIdReponse(id);
                return Response(response, response.Status);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        
        [HttpGet]
        public HttpResponseMessage Listar()
        {
            try
            {
                var response = _service.ListarResponse();
                return Response(response, EnumStatusObjeto.Sucesso);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}