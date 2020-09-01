using GerenciamentoPatrimonio.Dominio.Arguments.Usuario;
using GerenciamentoPatrimonio.Dominio.Interface.Service;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GerenciamentoPatrimonio.API.Controllers.Base;
using GerenciamentoPatrimonio.Infra.Transactions;
using GerenciamentoPatrimonio.Dominio.Arguments.EnumStatusObjetos;
using GerenciamentoPatrimonio.Infra;
using System.Linq;

namespace GerenciadorPatrimonio.API.Controllers
{

    public class UsuarioController : ControllerBase
    {
        private readonly IServiceUsuario _service;
        
        public UsuarioController(IServiceUsuario service, IUnityOfWork unityOfWork) : base(unityOfWork)
        {
            _service = service;
        }

       
        
        [HttpGet]
        public HttpResponseMessage Listar()
        {
            try
            {
                var response =  _service.ListarResponse();
                return Response(response, EnumStatusObjeto.Sucesso);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage SelecionarPorId(Guid id)
        {
            try
            {
                var response = _service.SelecionarPorIdResponse(id);
                return Response(response, response.Status);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage Inserir(InserirUsuarioRequest request)
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
        public HttpResponseMessage Editar(EditarUsuarioRequest request)
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
        public HttpResponseMessage Remover(RemoverUsuarioRequest request)
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
