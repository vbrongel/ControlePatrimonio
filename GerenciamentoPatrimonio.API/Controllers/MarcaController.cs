using GerenciamentoPatrimonio.API.Controllers.Base;
using GerenciamentoPatrimonio.Dominio.Arguments.EnumStatusObjetos;
using GerenciamentoPatrimonio.Dominio.Arguments.Marca;
using GerenciamentoPatrimonio.Dominio.Interface.Service;
using GerenciamentoPatrimonio.Infra.Transactions;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GerenciamentoPatrimonio.API.Controllers
{
    
    public class MarcaController : ControllerBase
    {
        private readonly IServiceMarca _service;

        public MarcaController(IUnityOfWork unityOfWork, IServiceMarca service) : base(unityOfWork)
        {
            _service = service;
        }
        
        
        [HttpPost]
        public HttpResponseMessage Inserir(InserirMarcaRequest request)
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
        public HttpResponseMessage Editar(EditarMarcaRequest request)
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

        
        [HttpGet]
        public HttpResponseMessage ListarPorId(Guid id)
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

        
        [HttpDelete]
        public HttpResponseMessage Remover(RemoverMarcaRequest request)
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

    }
}